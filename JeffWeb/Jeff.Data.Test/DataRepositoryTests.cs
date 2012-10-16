using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeff.Model.Domain;
using NUnit.Framework;

namespace Jeff.Data.Test
{
    [TestFixture]
    public class DataRepositoryTests
    {
        private DataRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new DataRepository();
        }

        [Test]
        public void ShouldGetContactPageConfiguration()
        {
            var result = _repository.GetPageConfigurations(PageType.Contact);

            Assert.IsNotNull(result);
            Assert.IsNotNullOrEmpty(result.First().EmailAddress);
        }
    }
}
