using Console_core_project.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class PersonSequencerTest
    {
        [Fact]
        public void NextPersonId_Counter()
        {
            // Arrange
            int expectedId1 = 1;
            int expectedId2 = 2;

            // Act
            int actualId1 = PersonSequencer.NextPersonId();
            int actualId2 = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(expectedId1, actualId1);
            Assert.Equal(expectedId2, actualId2);
        }

        [Fact]
        public void Reset_Sets_Zero()
        {
            // Arrange
            PersonSequencer.NextPersonId(); 

            // Act
            PersonSequencer.Reset();
            int actualId = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(1, actualId);
        }

    }
}
