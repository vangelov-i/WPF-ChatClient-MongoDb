namespace ChatSystem.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MongoDB.Driver;
    using Moq;

    using Data.Contracts;
    using Data.Repositories;
    using Model;

    [TestClass]
    public class RepositoryTests
    {
        private Mock<IChatSystemMongoDbContext> chatSystemContextMoq;
        private Mock<IMongoCollection<User>> usersCollectionMoq;
        private IList<User> usersData;
        private Repository<User> usersRepository = new Repository<User>();

        [TestInitialize]
        public void TestInitialize()
        {
            this.usersData = new List<User>();
            this.usersCollectionMoq = new Mock<IMongoCollection<User>>();
            this.chatSystemContextMoq = new Mock<IChatSystemMongoDbContext>();
            this.chatSystemContextMoq
                .Setup(c => c.GetCollection<User>())
                .Returns(this.usersCollectionMoq.Object);

            this.usersRepository = new Repository<User>(this.chatSystemContextMoq.Object);
        }

        [TestMethod]
        public void Add_SingleUser_ShouldReturnSameUser()
        {
            // Arrange
            this.usersCollectionMoq
                .Setup(u => u.InsertOne(It.IsAny<User>(), null, default(CancellationToken)))
                .Callback<User, InsertOneOptions, CancellationToken>(
                    (user, options, token) => this.usersData.Add(user));

            var userToAdd = new User("TestUser1", "user1Pass");

            // Act
            this.usersRepository.Add(userToAdd);

            string expectedUsername = userToAdd.Username;
            var actualUser = this.usersData.FirstOrDefault();

            // Assert
            Assert.IsNotNull(actualUser, "User was not added successfully.");
            Assert.AreEqual(
                expectedUsername, 
                actualUser.Username, 
                "Username of added user does not match.");
        }

        [TestMethod]
        public void Add_10Users_UsersCoundShouldBe10()
        {
            // Arrange
            this.usersCollectionMoq
                .Setup(u => u.InsertOne(It.IsAny<User>(), null, default(CancellationToken)))
                .Callback<User, InsertOneOptions, CancellationToken>(
                    (user, options, token) => this.usersData.Add(user));

            for (int i = 0; i < 10; i++)
            {
                var userToAdd = new User("TestUser" + i, $"user{i}Pass");

                // Act
                this.usersRepository.Add(userToAdd);
            }

            int expectedCount = 10;
            int actualCount = this.usersData.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount, "User cound is not 10.");
        }

        [Ignore]
        [TestMethod]
        public void Delete_AddSingleUserAndDeleteIt_ShouldReturnTrue()
        {
            // Arrange
            //this.usersCollectionMoq
            //    .Setup(u => u.DeleteOne(
            //        It.IsAny<FilterDefinition<User>>(), default(CancellationToken)))
            //        .Returns()

            // Act

            // Assert
        }
    }
}