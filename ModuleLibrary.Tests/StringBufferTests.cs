using System;
using Xunit;

namespace ModuleLibrary.Tests
{
    public class StringBufferTests
    {
        #region snippet_AppendAtStart_Passes_InputIsChar

        [Fact]
        public void AppendAtStart_Passes_InputIsChar()
        {
            // Arrange
            var str = new StringBuffer("-+-+");

            // Act
            str.AppendAtStart('+');

            // Assert
            Assert.Equal("+-+-+".ToCharArray(), str.CharArray);

        }

        #endregion

        #region snippet_AppendAtStart_ThrowsArgumentNullException_InputIsCharNull

        [Fact]
        public void AppendAtStart_ThrowsArgumentNullException_InputIsCharNull()
        {
            // Arrange
            var str = new StringBuffer("-+-+");

            // Act
            void Result()=>str.AppendAtStart(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);

        }

        #endregion

        #region snippet_AppendAtEnd_Passes_InputIsChar

        [Fact]
        public void AppendAtEnd_Passes_InputIsChar()
        {
            // Arrange
            var str = new StringBuffer("-+-+");

            // Act
            str.AppendAtEnd('-');

            // Assert
            Assert.Equal("-+-+-".ToCharArray(), str.CharArray);

        }

        #endregion

        #region snippet_AppendAtEnd_ThrowsArgumentNullException_InputIsCharNull

        [Fact]
        public void AppendAtEnd_ThrowsArgumentNullException_InputIsCharNull()
        {
            // Arrange
            var str = new StringBuffer("-+-+");

            // Act
            void Result() => str.AppendAtEnd(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);

        }

        #endregion

        #region snippet_CompareTo_Passes_InputIsChar

        [Fact]
        public void CompareTo_Passes_InputIsChar()
        {
            // Arrange
            var str = new StringBuffer("-+-+");

            // Act
            var result =str.CompareTo("-+-+");

            // Assert
            Assert.True(result);

        }

        #endregion

        #region snippet_CompareTo_ThrowsArgumentNullException_InputIsCharNull

        [Fact]
        public void CompareTo_ThrowsArgumentNullException_InputIsCharNull()
        {
            // Arrange
            var str = new StringBuffer("-+-+");

            // Act
            void Result() => str.CompareTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);

        }

        #endregion

        #region snippet_CompareToReverse_Passes_InputIsChar

        [Fact]
        public void CompareToReverse_Passes_InputIsChar()
        {
            // Arrange
            var str = new StringBuffer("-+-+");

            // Act
            var result = str.CompareToReverse("-+-+");

            // Assert
            Assert.True(result);

        }

        #endregion

        #region snippet_CompareToReverse_ThrowsArgumentNullException_InputIsCharNull

        [Fact]
        public void CompareToReverse_ThrowsArgumentNullException_InputIsCharNull()
        {
            // Arrange
            var str = new StringBuffer("-+-+");

            // Act
            void Result() => str.CompareToReverse(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);

        }

        #endregion
    }
}
