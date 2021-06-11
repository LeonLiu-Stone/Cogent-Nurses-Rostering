using Xunit;
using Moq;
using Nurses.Rostering;

namespace Nurses.Tests.Rostering
{
    public class NurseTests
    {
        private static string name = "Natasha";
        private static string uid = "19ab7c";

        #region Attributes

        [Fact]
        public void Nurse_Uid_SetGet()
        {
            var nurse = new Nurse();
            nurse.uid = uid;

            Assert.Equal(nurse.uid, uid);
        }

        [Fact]
        public void Nurse_Name_SetGet()
        {
            var nurse = new Nurse();
            nurse.name = name;

            Assert.Equal(nurse.name, name);
        }
        
        #endregion

        #region Equality

        [Fact]
        public void Nurse_Equality_WhenOtherHasSameNameAndUid_IsEqual()
        {
            Assert.Equal(
                new Nurse { name = name, uid = uid },
                new Nurse { name = name, uid = uid }
            );
        }

        [Fact]
        public void Nurse_Equality_WhenOtherHasSameObjectReference_IsEqual()
        {
            var nurseA = new Nurse { name = name, uid = uid };
            var nurseB = nurseA;

            Assert.Equal(nurseA, nurseB);
        }

        [Fact]
        public void Nurse_Equality_WhenOtherHasSameUidDifferentName_IsNotEqual()
        {
            var nurse = new Nurse { name = "Natasha Romanoff", uid = uid };
            var sameNurse = new Nurse { name = "Clint Barton", uid = uid };

            Assert.NotEqual(nurse, sameNurse);
        }

        [Fact]
        public void Nurse_Equality_WhenOtherHasSameNameDifferentUid_IsNotEqual()
        {
            var nurse = new Nurse { name = name, uid = "19ab7c45" };
            var sameNurse = new Nurse { name = name, uid = "20ef8g56" };

            Assert.NotEqual(nurse, sameNurse);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("19ab7c")]
        [InlineData("Natasha")]
        [InlineData(999)]
        [InlineData(true)]
        [InlineData(false)]
        public void Nurse_Equality_WhenOtherIsNotNurse_IsNotEqual(object testInput)
        {
            Assert.NotEqual(new Nurse { name = name, uid = uid }, testInput);
        }

        #endregion
    
        #region GetHashCode

        [Fact]
        public void Nurse_GetHashCode_ReturnsHashCodeUsingUidAndName()
        {
            var nurse = new Nurse { name = name, uid = uid };

            var sameNurse = new Nurse { name = name, uid = uid };
            Assert.Equal(nurse.GetHashCode(), sameNurse.GetHashCode());

            var otherNurse = new Nurse { name = name, uid = "20xy8z56" };
            Assert.NotEqual(nurse.GetHashCode(), otherNurse.GetHashCode());

            var anotherNurse = new Nurse { name = "Bucky Barnes", uid = uid };
            Assert.NotEqual(nurse.GetHashCode(), anotherNurse.GetHashCode());
        }

        #endregion
    }
}