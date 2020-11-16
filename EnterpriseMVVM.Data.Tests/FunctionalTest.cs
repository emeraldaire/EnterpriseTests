using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseMVVM.Data.Tests
{
    [TestClass]
    public class FunctionalTest
    {
        //The methods are virtual instead of static, because they'll be instantiate with the class when the test runner runs.
        [TestInitialize]
        public virtual void TestInitialize()
        {
            using (var db = new DataContext())
            {
                if (db.Database.CanConnect())
                {
                    db.Database.EnsureDeleted();
                }

                db.Database.EnsureCreated();
            }
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            using (var db = new DataContext())
            {
                if (db.Database.CanConnect())
                {
                    db.Database.EnsureDeleted();
                }
            }
        }

    }
}
