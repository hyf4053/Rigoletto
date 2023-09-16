using System;
using Actors.Character;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("dataToSave")]
	public class ES3UserType_MainCharacter : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_MainCharacter() : base(typeof(MainCharacter)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (MainCharacter)obj;
			
			writer.WriteProperty("dataToSave", instance.dataToSave, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(Actors.Character.CharacterDataStructure)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (MainCharacter)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "dataToSave":
						instance.dataToSave = reader.Read<Actors.Character.CharacterDataStructure>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_MainCharacterArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MainCharacterArray() : base(typeof(MainCharacter[]), ES3UserType_MainCharacter.Instance)
		{
			Instance = this;
		}
	}
}