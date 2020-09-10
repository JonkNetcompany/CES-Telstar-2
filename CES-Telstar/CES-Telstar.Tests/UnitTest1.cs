using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CES_Telstar.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var sut = new 

            // Act


            // Assert

        }




        private List<Segment> MockSegments()
        {
            return new List<Segment>
            {
                new Segment
                {
                    Locations = new List<Location>
                    {
                        new Location
                        {
                            CityName = "A"
                        },
                        new Location
                        {
                            CityName = "B"
                        }
                    },
                    
                }
            };
        }
    }
}
