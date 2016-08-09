using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChatSystem.Tests
{
    using System.Linq;

    using ChatSystem.Data.Repositories;
    using ChatSystem.Model;

    [TestClass]
    public class RepositoryTests
    {
        private Repository<User> usersRepository = new Repository<User>();

        //[TestInitialize]
        //private void TestInitialize()
        //{
        //    this.usersRepository = new Repository<User>();
        //}

        //[TestMethod]
        //public void Constructor_ShouldNotThrow()
        //{
        //}

        [TestMethod]
        public void Update_ShouldChangePeshotoPeshoNov()
        {
            var pesho = this.usersRepository
                .Search(u => u.Username == "Pesho")
                .FirstOrDefault();

            pesho.Username = "PeshoNov";

            this.usersRepository.Update(pesho);

            bool peshoIsUpdated = this.usersRepository
                .Search(u => u.Username == "PeshoNov")
                .Any();

            Assert.IsTrue(peshoIsUpdated, "User was not updated correctly");
        }

        [TestMethod]
        public void Delete_DeleteingSingleDocument_ShouldReturnTrue()
        {
            var pesho = this.usersRepository
                .Search(u => u.Username == "Pesho")
                .FirstOrDefault();

            bool userDeleted = this.usersRepository.Delete(pesho);

            Assert.IsTrue(userDeleted, "User was not deleted.");
        }
    }
}
