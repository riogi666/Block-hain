﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Tests
{
    [TestClass()]
    public class ChainTests
    {
        [TestMethod()]
        public void ChainTest()
        {
            var chain = new Chain();
            chain.Add("Code", "Admin");

            Assert.AreEqual(2, chain.Blocks.Count);
            Assert.AreEqual("Code", chain.Last.Data);
        }
    }
}