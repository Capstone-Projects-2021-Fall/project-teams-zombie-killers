using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{


    public class TestPersistentData
    {
        
        [Test]
        public void PersistentData_removes_keys_after_call_to_DeleteAllForPlayer()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.SetInt("UnitTestInt1", 1);
            PersistentData.SetInt("UnitTestInt2", 2);
            
            PersistentData.DeleteAllForPlayer();
            
            int numberOfKeys = PersistentData.GetKeys().Length;
            Assert.AreEqual(0, numberOfKeys);
        }

        [Test]
        public void PersistentData_does_not_remove_other_players_removes_keys_after_call_to_DeleteAllForPlayer()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);

            PersistentData.SetPlayerName("UnitTestName2");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);
            PersistentData.SetInt("UnitTestInt2", 2);

            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();

            PersistentData.SetPlayerName("UnitTestName2");
            int numberOfKeys = PersistentData.GetKeys().Length;
            
            Assert.AreEqual(2, numberOfKeys);
        }


        [Test]
        public void PersistentData_stores_the_players_keys_correctly_1_key()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);

            Assert.IsTrue(PersistentData.GetKeys().Length == 1 &&
                PersistentData.GetKeys()[0].Equals("UnitTestInt1"));
        }


        [Test]
        public void PersistentData_stores_the_players_keys_correctly_2_keys()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);
            PersistentData.SetInt("UnitTestInt2", 2);

            Assert.IsTrue(PersistentData.GetKeys().Length == 2 &&
                PersistentData.GetKeys()[0].Equals("UnitTestInt1") &&
                PersistentData.GetKeys()[1].Equals("UnitTestInt2"));
        }

        [Test]
        public void PersistentData_stores_the_players_keys_correctly_with_multiple_players()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);
            PersistentData.SetInt("UnitTestInt2", 2);

            PersistentData.SetPlayerName("UnitTestName2");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt3", 3);

            PersistentData.SetPlayerName("UnitTestName1");
            Assert.IsTrue(PersistentData.GetKeys().Length == 2 &&
                PersistentData.GetKeys()[0].Equals("UnitTestInt1") &&
                PersistentData.GetKeys()[1].Equals("UnitTestInt2"));
        }

        [Test]
        public void PersistentData_stores_string_values_correctly()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetString("UnitTestString1", "String 1");
            PersistentData.SetString("UnitTestString2", "String 2");

            PersistentData.SetPlayerName("UnitTestName2");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetString("UnitTestString1", "String 3");
            PersistentData.SetString("UnitTestString2", "String 4");

            PersistentData.SetPlayerName("UnitTestName1");
            Assert.AreEqual("String 1", PersistentData.GetString("UnitTestString1"));
        }

        [Test]
        public void PersistentData_stores_float_values_correctly()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetFloat("UnitTestFloat1", 0.1f);
            PersistentData.SetFloat("UnitTestFloat2", 0.2f);

            PersistentData.SetPlayerName("UnitTestName2");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetFloat("UnitTestFloat1", 0.3f);
            PersistentData.SetFloat("UnitTestFloat2", 0.4f);

            PersistentData.SetPlayerName("UnitTestName1");
            Assert.AreEqual(0.1f, PersistentData.GetFloat("UnitTestFloat1"), 0.0000001f);
        }

        [Test]
        public void PersistentData_stores_int_values_correctly()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);
            PersistentData.SetInt("UnitTestInt2", 2);

            PersistentData.SetPlayerName("UnitTestName2");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 3);
            PersistentData.SetInt("UnitTestInt2", 4);

            PersistentData.SetPlayerName("UnitTestName1");
            Assert.AreEqual(1, PersistentData.GetInt("UnitTestInt1"));
        }

        [Test]
        public void PersistentData_HasKey()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);

            Assert.IsTrue(PersistentData.HasKey("UnitTestInt1"));
        }

        [Test]
        public void PersistentData_HasKey_key_not_yet_used()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);

            Assert.IsFalse(PersistentData.HasKey("UnitTestInt7"));
        }


        /// <summary>
        /// Confirms that the key is deleted after a call to the DeleteKey function
        /// </summary>
        [Test]
        public void PersistentData_HasKey_after_DeleteKey()
        {
            PersistentData.SetPlayerName("UnitTestName1");
            PersistentData.DeleteAllForPlayer();
            PersistentData.SetInt("UnitTestInt1", 1);
            PersistentData.DeleteKey("UnitTestInt1");


            Assert.IsFalse(PersistentData.HasKey("UnitTestInt1"));
        }

        [Test]
        public void PersistentData_HasKey_after_DeleteAllForPlayer()
        {
            PersistentData.SetPlayerName("UnitTestName1");

            PersistentData.SetInt("UnitTestInt1", 1);
            PersistentData.DeleteAllForPlayer();

            Assert.IsFalse(PersistentData.HasKey("UnitTestInt1"));
        }


        //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        //// `yield return null;` to skip a frame.
        //[UnityTest]
        //public IEnumerator TestPersistentDataWithEnumeratorPasses()
        //{
        //    // Use the Assert class to test conditions.
        //    // Use yield to skip a frame.
        //    yield return null;
        //}
    }
}
