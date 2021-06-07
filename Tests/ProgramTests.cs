using Xunit;

namespace Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("ГЛАВ123РЫБА56", 60, false, "ГЛАВ183РЫБА16")]
        [InlineData("ГАЗ4ПРОМ5БАНК97", 15, false, "ГАЗ9ПРОМ0БАНК12")]
        [InlineData("ААА123БББ11", 95, true, "ААА218ББВ06")]
        public void AddToEveryNumberTest(string str, int addendum, bool shiftDigit, string expected)
        {
            // Arrange
            // Act
            var result = PracticeTasks.Program.AddToEveryNumber(str, addendum, shiftDigit);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}