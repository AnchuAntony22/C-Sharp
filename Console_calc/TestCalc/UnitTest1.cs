using Console_calc;

namespace TestCalc
{
    public class UnitTest1
    {
       
        [Fact]
        public void TestAddition()
        {
            Calc calc = new Calc();
            Assert.Equal(5m, calc.Addition(2m, 3m));
            Assert.Equal(-1.2m, calc.Addition(new decimal[] { 2.5m, -3.7m, 0m }));
           
        }

        [Fact]
        public void TestSubtraction()
        {
            Calc calc = new Calc();
            Assert.Equal(1m, calc.Subtraction(4m, 3m));
            Assert.Equal(6.2m, calc.Subtraction(new decimal[] { 10m, 2.5m, 1.3m }));
            
        }

        [Fact]
        public void TestMultiplication()
        {
            Calc calc = new Calc();
            Assert.Equal(15m, calc.Multiplication(3m, 5m));
           
        }

        [Fact]
        public void TestDivision()
        {
            Calc calc = new Calc();
            Assert.Equal(2m, calc.Division(6m, 3m));
            Assert.Throws<DivideByZeroException>(() => calc.Division(5m, 0m));
            
        }
    }
}