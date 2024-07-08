﻿using Console_core_project.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TodoSequencerTest
    {
        [Fact]
        public void Todo_Counter()
        {
            // Arrange
            int expectedId1 = 1;
            int expectedId2 = 2;

            // Act
            int actualId1 = TodoSequencer.Nexttodo();
            int actualId2 = TodoSequencer.Nexttodo();

            // Assert
            Assert.Equal(expectedId1, actualId1);
            Assert.Equal(expectedId2, actualId2);
        }

        [Fact]
        public void Reset_Sets_Zero()
        {
            // Arrange
            TodoSequencer.Nexttodo();

            // Act
            TodoSequencer.Reset();
            int actualId = TodoSequencer.Nexttodo();

            // Assert
            Assert.Equal(1, actualId);
        }
    }
}
