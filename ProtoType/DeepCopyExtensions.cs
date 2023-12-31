﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ProtoType
{
    public static class DeepCopyExtensions
    {
        //public static T DeepCopy<T>(this IDeepCopyable<T> item )where T: new()
        //{
        //    return item.DeepCopy();
        //}
        //
        //public static T DeepCopy<T>(this T person)
        //    where T : Person, new()
        //{
        //    return ((IDeepCopyable<T>)person).DeepCopy();
        //}

        public static T DeepCopy<T>(this T self) where T : new()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                object copy = formatter.Deserialize(stream);
                stream.Close();
                return (T)copy;
            }
        }
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }
}
