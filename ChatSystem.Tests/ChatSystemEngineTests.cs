namespace ChatSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using ChatSystem.Data;
    using ChatSystem.Data.Contracts;
    using ChatSystem.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ChatSystemEngineTests
    {
        private IList<User> usersCollection;
        private Mock<IRepository<User>> repoMock;
        private Mock<IChatSystemData> systemDataMock;
        private IChatSystemEngine chatSystemEngine;

        [TestInitialize]
        public void TestInitialize()
        {
            this.usersCollection = new List<User>();
            this.repoMock = new Mock<IRepository<User>>();
            this.systemDataMock = new Mock<IChatSystemData>();

            this.repoMock
                .Setup(r => r.Search(It.IsAny<Expression<Func<User, bool>>>(), 0))
                .Returns<Expression<Func<User, bool>>, int>(
                    (conditions, skipCount) =>
                    {
                        var result = this.usersCollection
                            .Where(user => conditions.Compile().Invoke(user))
                            .Skip(skipCount)
                            .ToList();

                        return result;
                    });

            this.systemDataMock
                .Setup(d => d.Users)
                .Returns(this.repoMock.Object);

            this.chatSystemEngine = new ChatSystemEngine(systemDataMock.Object);
        }

        [TestMethod]
        public void LogIn_ExistingUser_ShouldNotThrow()
        {
            // Arrange
            this.usersCollection.Add(new User("Goshko", "goshko"));
            this.usersCollection.Add(new User("Peshko", "peshko"));

            // Act
            this.chatSystemEngine.LogIn("Peshko", "peshko");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LogIn_NonExistingUser_ShouldThrow()
        {
            // Act
            chatSystemEngine.LogIn("Peshko", "peshko");
        }
    }
}