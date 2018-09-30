using Newtonsoft.Json;
using System;

namespace Help.Library
{
  public class JSONSerializer
  {
    //public static string ObjectToJSON(object o)
    //{
    //  var json = new JavaScriptSerializer().Serialize(o);
    //  return json;
    //}

    //public static object JSONToObject(string json)
    //{
    //  var obj = new JavaScriptSerializer().Deserialize(json, typeof(object));
    //  return obj;
    //}

    public static object JSONToObject(string json, Type newType)
    {
      return JsonConvert.DeserializeObject(json, newType);
    }

    public static string ObjectToJSON(object o)
    {
      return JsonConvert.SerializeObject(o);
    }
  }
}