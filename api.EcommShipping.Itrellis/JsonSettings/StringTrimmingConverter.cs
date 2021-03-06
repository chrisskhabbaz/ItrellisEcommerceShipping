﻿using System;
using Newtonsoft.Json;

namespace api.EcommShipping.Itrellis.JsonSettings
{
	public class StringTrimmingConverter: JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.String && reader.Value != null)
			{
				return ((string)reader.Value).Trim();
			}

			return reader.Value;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var text = (string)value;
			if (text == null)
				writer.WriteNull();
			else
				writer.WriteValue(text.Trim());
		}
	}
}
