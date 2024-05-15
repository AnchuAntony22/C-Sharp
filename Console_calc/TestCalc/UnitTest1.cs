using Console_calc;

namespace TestCalc
{
    public class UnitTest1
    {
       
       
        [Fact]
        public void Addition_PositiveNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Addition(2, 3, 4);
            Assert.Equal(9, result);
        }

        [Fact]
        public void Addition_NegativeNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Addition(-2, -3, -4);
            Assert.Equal(-9, result);
        }

        [Fact]
        public void Addition_DecimalNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Addition(1.5m, 2.5m, -3.5m);
            Assert.Equal(0.5m, result);
        }


        [Fact]
        public void Subtraction_PositiveNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Subtraction(2, 3, 4);
            Assert.Equal(9, result);
        }

        [Fact]
        public void Subtraction_NegativeNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Subtraction(-2, -3, -4);
            Assert.Equal(-9, result);
        }

        [Fact]
        public void Subtraction_DecimalNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Subtraction(1.5m, 2.5m, -3.5m);
            Assert.Equal(0.5m, result);
        }
        [Fact]
        public void Multiplication_PositiveNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Multiplication(2, 3);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiplication_NegativeNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Multiplication(-2, 3);
            Assert.Equal(-6, result);
        }

        [Fact]
        public void Multiplication_DecimalNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Multiplication(1.5m, 2.5m);
            Assert.Equal(3.75m, result);
        }
        [Fact]
        public void Division_PositiveNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Division(10, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Division_NegativeNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Division(-10, 2);
            Assert.Equal(-5, result);
        }

        [Fact]
        public void Division_DecimalNumbers()
        {
            Calc calc = new Calc();
            decimal result = calc.Division(10m, 3m);
            Assert.Equal(3.3333333333333333333333333m, result);
        }

        [Fact]
        public void Division_DivideByZero()
        {
            Calc calc = new Calc();
            Assert.Throws<DivideByZeroException>(() => calc.Division(10m, 0));
        }


    }
}