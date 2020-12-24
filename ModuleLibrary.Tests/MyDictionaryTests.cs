using System;
using System.Collections.Generic;
using Xunit;

namespace ModuleLibrary.Tests
{
    public class MyDictTests
    {
        #region snippet_Add_Passes_InputIsKeyAndPair

        [Fact]
        public void Add_Passes_InputIsCorrect()
        {
            // Arrange
            var dictionary = new MyDict<int,int>();


            // Act
            dictionary.Add(5,5);

            // Assert
            Assert.Equal(1,dictionary.Count);

        }

        #endregion

        #region snippet_Add_Passes_InputIsKeyPairValue

        [Fact]
        public void Add_Passes_InputIsKeyPairValue()
        {
            // Arrange
            var dictionary = new MyDict<int, int>();


            // Act
            dictionary.Add(new KeyValuePair<int, int>(5,5));

            // Assert
            Assert.Equal(1, dictionary.Count);

        }

        #endregion

        #region snippet_Add_ThrowsArgumentNullException_InputIsKeyAndValueNull

        [Fact]
        public void Add_ThrowsArgumentNullException_InputIsKeyAndValueNull()
        {
            // Arrange
            var dictionary = new MyDict<string, string>();


            // Act
            void Result()=>dictionary.Add(null, null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);

        }

        #endregion

        #region snippet_Contains_Passes_InputIsKeyPairValue

        [Fact]
        public void Contains_Passes_InputIsKeyPairValue()
        {
            // Arrange
            var dictionary = new MyDict<int, int>();
            var pair = new KeyValuePair<int, int>(5, 5);
            dictionary.Add(pair);

            // Act
            var result= dictionary.Contains(pair);

            // Assert
            Assert.True(result);

        }

        #endregion

        #region snippet_ContainsKey_Passes_InputIsKey

        [Fact]
        public void ContainsKey_Passes_InputIsKey()
        {
            // Arrange
            var dictionary = new MyDict<int, int>();
            var pair = new KeyValuePair<int, int>(5, 5);
            dictionary.Add(pair);

            // Act
            var result = dictionary.ContainsKey(pair.Key);

            // Assert
            Assert.True(result);

        }

        #endregion

        #region snippet_ContainsKey_ThrowsArgumentNullException_InputIsKeyNull

        [Fact]
        public void ContainsKey_ThrowsArgumentNullException_InputIsKeyNull()
        {
            // Arrange
            var dictionary = new MyDict<string, string>();


            // Act
            void Result() => dictionary.ContainsKey(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);

        }

        #endregion

        #region snippet_Remove_Passes_InputIsKeyPairValue

        [Fact]
        public void Remove_Passes_InputIsKeyPairValue()
        {
            // Arrange
            var dictionary = new MyDict<int, int>();
            var pair = new KeyValuePair<int, int>(5, 5);
            dictionary.Add(pair);

            // Act
            var result = dictionary.Remove(pair);

            // Assert
            Assert.True(result);

        }

        #endregion

        #region snippet_Remove_Passes_InputIsKey

        [Fact]
        public void Remove_Passes_InputIsKey()
        {
            // Arrange
            var dictionary = new MyDict<int, int>();
            var pair = new KeyValuePair<int, int>(5, 5);
            dictionary.Add(pair);

            // Act
            var result = dictionary.Remove(pair.Key);

            // Assert
            Assert.True(result);

        }

        #endregion

        #region snippet_Remove_ThrowsArgumentNullException_InputIsKeyNull

        [Fact]
        public void Remove_ThrowsArgumentNullException_InputIsKeyNull()
        {
            // Arrange
            var dictionary = new MyDict<string, string>();


            // Act
            void Result() => dictionary.Remove(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);

        }

        #endregion

    }
}
