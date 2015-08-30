using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Lubala.Core.Serialization.Attributes;

namespace Lubala.Core.Serialization
{
    internal class WechatXmlSerializer : IXmlSerializer
    {
        public void Serialize<T>(T obj, Stream targetStream)
        {
            var targetType = obj.GetType();
            var xml = new XmlDocument();
            var root = CreateElement("xml", obj, targetType, xml);
            xml.AppendChild(root);
            xml.Save(targetStream);
        }

        public T Deserialize<T>(XDocument xml)
        {
            return (T) Deserialize(xml, typeof (T));
        }

        public object Deserialize(XDocument xml, Type type)
        {
            var root = xml.Root;
            var target = CreateObject(root, type);
            return target;
        }

        private XmlElement CreateElement(string elementName, object obj, Type type, XmlDocument xml)
        {
            var element = xml.CreateElement(elementName);

            var properties = type.GetProperties(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.GetProperty |
                BindingFlags.SetProperty |
                BindingFlags.Instance);

            foreach (var propertyInfo in properties)
            {
                var ignoreAttr = propertyInfo.GetCustomAttribute<IgnoreAttribute>();
                if (ignoreAttr != null)
                {
                    continue;
                }

                var node = CreateNode(obj, propertyInfo, xml);
                element.AppendChild(node);
            }

            return element;
        }

        private XmlElement CreateNode(object obj, PropertyInfo propertyInfo, XmlDocument xml)
        {
            var nodeAttr = propertyInfo.GetCustomAttribute<NodeAttribute>();
            var arrayAttr = propertyInfo.GetCustomAttribute<ArrayAttribute>();
            var arrayItemAttr = propertyInfo.GetCustomAttribute<ArrayItemAttribute>();

            var nodeName = nodeAttr?.NodeName
                           ?? arrayAttr?.ArrayName
                           ?? propertyInfo.Name;


            var node = xml.CreateElement(nodeName);
            if (arrayAttr == null)
            {
                SetupNodeValue(propertyInfo, obj, node, xml);
            }
            else
            {
                var elementType = propertyInfo.PropertyType.GetElementType();
                var lists = propertyInfo.GetValue(obj) as IEnumerable;
                if (lists != null)
                {
                    var itemName = arrayItemAttr?.ItemName
                                   ?? elementType.Name;
                    foreach (var l in lists)
                    {
                        var element = CreateElement(itemName, l, elementType, xml);
                        node.AppendChild(element);
                    }
                }
            }
            return node;
        }

        private void SetupNodeValue(PropertyInfo propertyInfo, object obj, XmlElement node, XmlDocument xml)
        {
            var raw = propertyInfo.GetValue(obj);
            var propertyType = propertyInfo.PropertyType;

            var str = FormatValue(raw, propertyType);

            var cdata = xml.CreateCDataSection(str);
            node.AppendChild(cdata);
        }

        private string FormatValue(object raw, Type propertyType)
        {
            // TODO: add more format here.
            if (propertyType == typeof (string))
            {
                return (string) raw;
            }

            return raw.ToString();
        }

        private object CreateObject(XElement root, Type type)
        {
            var obj = Activator.CreateInstance(type);
            var properties = type.GetProperties(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.GetProperty |
                BindingFlags.SetProperty |
                BindingFlags.Instance);
            var propertyDict = CreateMappingDict(properties);

            foreach (var element in root.Elements())
            {
                var elementName = element.Name.LocalName;
                PropertyInfo propertyInfo;
                if (propertyDict.TryGetValue(elementName, out propertyInfo))
                {
                    if (propertyInfo.PropertyType.IsArray)
                    {
                        var arrayItemAttr = propertyInfo.GetCustomAttribute<ArrayItemAttribute>();
                        if (arrayItemAttr != null)
                        {
                            var innerType = propertyInfo.PropertyType.GetElementType();
                            var listType = typeof (List<>);
                            var instanceType = listType.MakeGenericType(innerType);
                            var list = Activator.CreateInstance(instanceType);
                            foreach (var subElement in element.Elements())
                            {
                                var item = CreateObject(subElement, innerType);
                                var addMethod = list.GetType().GetMethod("Add");
                                addMethod.Invoke(list, new[] {item});
                            }

                            var toArrayMethod = list.GetType().GetMethod("ToArray");
                            var final = toArrayMethod.Invoke(list, new object[0]);
                            propertyInfo.SetValue(obj, final);
                        }
                    }
                    else
                    {
                        SetPropertyValue(obj, propertyInfo, element.Value);
                    }
                }
            }

            return obj;
        }

        private void SetPropertyValue(object obj, PropertyInfo propertyInfo, string value)
        {
            if (propertyInfo.CanWrite)
            {
                var v = Convert.ChangeType(value, propertyInfo.PropertyType);
                propertyInfo.SetValue(obj, v);
            }
        }

        private IDictionary<string, PropertyInfo> CreateMappingDict(PropertyInfo[] properties)
        {
            var dict = new Dictionary<string, PropertyInfo>();
            foreach (var propertyInfo in properties)
            {
                var nodeAttr = propertyInfo.GetCustomAttribute<NodeAttribute>();
                var arrayAttr = propertyInfo.GetCustomAttribute<ArrayAttribute>();
                var elementName = nodeAttr?.NodeName
                                  ?? arrayAttr?.ArrayName
                                  ?? propertyInfo.Name;
                dict.Add(elementName, propertyInfo);
            }
            return dict;
        }

        private PropertyInfo GetPropertyInfo(PropertyInfo[] properties, string elementName)
        {
            foreach (var propertyInfo in properties)
            {
                var nodeAttr = propertyInfo.GetCustomAttribute<NodeAttribute>();
                var arrayAttr = propertyInfo.GetCustomAttribute<ArrayAttribute>();
                //var arrayItemAttr = propertyInfo.GetCustomAttribute<ArrayItemAttribute>();

                if (arrayAttr != null && arrayAttr.ArrayName == elementName)
                {
                    return propertyInfo;
                }

                if (nodeAttr != null && nodeAttr.NodeName == elementName)
                {
                    return propertyInfo;
                }

                if (propertyInfo.Name == elementName)
                {
                    return propertyInfo;
                }
            }

            return null;
        }
    }
}