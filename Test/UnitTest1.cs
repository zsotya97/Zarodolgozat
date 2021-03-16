using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Projekt.Models;
using System.Linq;


namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Novenyek()
        {
            TestModelNoveny _context = new TestModelNoveny();
            Assert.IsTrue(_context.elofordulas.First().Honap.Length>0);
            
        }
    }
}