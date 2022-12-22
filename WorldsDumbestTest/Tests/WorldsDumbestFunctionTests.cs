using System;

namespace WorldsDumbestTest.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        // Naming Convention - ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsGreatDaneIfZero_ReturnString()
        {
            try
            {
                // Arrange - Go get variables needed to run this function
                int num = 1;
                WorldsDumbestFunction worldsDumbestFunction = new WorldsDumbestFunction();

                // Act - Execute this function
                string result = worldsDumbestFunction.ReturnsGreatDaneIfZero(num);

                // Assert - Whatever is returned, is it what you want?
                if (result == "Great Dane")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction.ReturnsGreatDaneIfZero.ReturnString");
                }
                else 
                {
                    Console.WriteLine("FAILED: WorldsDumbestFunction.ReturnsGreatDaneIfZero.ReturnString");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);                
            }
        }
    }
}
