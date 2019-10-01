using System;
using System.Text;
using Newtonsoft.Json;

namespace RabbitMQDemo
{
    public static class ObjectSerialize
    {
        public static byte[] Serialize(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(obj);
            return Encoding.ASCII.GetBytes(json);
        }

        public static T DeSerialize<T>(this byte[] bytes)
        {
            var json = Encoding.Default.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string DeSerializeText(this byte[] arrBytes)
        {
            return Encoding.Default.GetString(arrBytes);
        }
    }
}