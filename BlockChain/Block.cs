using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    /// <summary>
    /// Блок данных.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Идентификатор блока.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// данные блока.
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// Дата и время создания блока.
        /// </summary>
        public DateTime Created { get; private set; }

        /// <summary>
        /// Хэш блока.
        /// </summary>
        public string Hash { get; private set; }

        /// <summary>
        /// Хэш предыдущего блока
        /// </summary>
        public string PreviousHash { get; private set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string User { get; private set; }

        /// <summary>
        /// Конструктор для создания Генезис блока.
        /// </summary>
        public Block()
        {
            Id = 1;
            Data = "Genesis block";
            Created = DateTime.Parse("26.03.2020 00:00:00.000");
            PreviousHash = "";
            User = "Genesis";

            var data = GetData();
            Hash = GetHash(data);
        }

        /// <summary>
        /// Конструктор обычного блока.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="user"></param>
        /// <param name="block"></param>
        public Block(String data, string user, Block block)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException("Пустой аргумент data", nameof(data));
            }

            if (string.IsNullOrWhiteSpace(user))
            {
                throw new ArgumentNullException("Пустой аргумент user", nameof(user));
            }

            if (block == null)
            {
                throw new ArgumentNullException("Пустой аргумент block", nameof(block));
            }

            Data = data;
            User = user;
            PreviousHash = block.Hash;
            Created = DateTime.UtcNow;
            Id = block.Id + 1;

            var blockData = GetData();
            Hash = GetHash(blockData);
        }

        /// <summary>
        /// Получение значимых данных.
        /// </summary>
        /// <returns></returns>
        private string GetData()
        {
            string result = "";
            result += Id.ToString();
            result += Data;
            result += Created.ToString("dd.MM.yyyy HH:mm:ss.fff");
            result += PreviousHash;
            result += User;

            return result;
        }

        /// <summary>
        /// Хэширование данных.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string GetHash(string data)
        {
            var message = Encoding.ASCII.GetBytes(data);
            var hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += string.Format("{0:x2}", x);
            }
            return hex;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
