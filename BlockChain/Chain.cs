﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    /// <summary>
    /// Цепочка блоков.
    /// </summary>
    public class Chain
    {
        /// <summary>
        /// Все блоки.
        /// </summary>
        public List<Block> Blocks { get; private set; }
        /// <summary>
        /// Последний блок.
        /// </summary>
        public Block Last { get; private set; }

        /// <summary>
        /// Создание новой цепочки.
        /// </summary>
        public Chain()
        {
            Blocks = new List<Block>();
            var genesisBlock = new Block();

            Blocks.Add(genesisBlock);
            Last = genesisBlock;
        }

        /// <summary>
        /// Добавить блок.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        public void Add(string data, string user)
        {
            var block = new Block(data, user, Last);
            Blocks.Add(block);
            Last = block;
        }
    }
}
