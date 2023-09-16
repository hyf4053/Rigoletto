using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_CharacterData : ES3ScriptableObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CharacterData() : base(typeof(ScriptableObjectClass.CharacterData)){ Instance = this; priority = 1; }


		protected override void WriteScriptableObject(object obj, ES3Writer writer)
		{
			var instance = (ScriptableObjectClass.CharacterData)obj;
			
		}

		protected override void ReadScriptableObject<T>(ES3Reader reader, object obj)
		{
			var instance = (ScriptableObjectClass.CharacterData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CharacterDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CharacterDataArray() : base(typeof(ScriptableObjectClass.CharacterData[]), ES3UserType_CharacterData.Instance)
		{
			Instance = this;
		}
	}
}