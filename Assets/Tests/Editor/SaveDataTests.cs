using System.IO;
using MoreMountains.CorgiEngine;
using NUnit.Framework;
using UnityEngine.WSA;
using UnityEngine;

namespace Tests.Editor
{
    [TestFixture]
    public class SaveDataTests
    {
        [Test, Category("SaveData Directory Test")]
        public void testSaveDataDirectory()
        {
           SaveData saveData = new SaveData("scene1");
           string actual = saveData.SetPathDirectory(SaveData.DirectoryUseCase.SaveFile);
           Debug.Log(actual);
        }
        
    }
}