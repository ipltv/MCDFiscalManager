using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCDFiscalManager.BusinessModel.Model;
using System.Runtime.Serialization;

namespace MCDFiscalManager.DataController
{
    /// <summary>
    /// Базовый класс для контроллеров различных вспомогательных данных (компании, ОФД, пользователи).
    /// Это абстрактный класс.
    /// </summary>
    public abstract class AuxiliaryDataController<T> : IFileData
    {
        /// <summary>
        /// Словарь представляющий коллекцию загруженных элементов (пользователь, ОФД и т.д.).
        /// </summary>
        protected Dictionary<string, T> elements;
        /// <summary>
        /// Текущий элемент.
        /// </summary>
        protected T curentElement;
        /// <summary>
        /// Базовый конструктор, который создает контроллер путем извлечения данных о пользователях из файла с помощью соотвествующего форматера.
        /// Если данные из файла не удается прочитать, будет задано значение по умолчанию.
        /// </summary>
        /// <param name="formatter">Форматер для десериализации данных из файла.</param>
        /// <param name="userDataFile">Файл с данными о пользователях.</param>
        protected AuxiliaryDataController(IFormatter formatter, FileInfo userDataFile)
        {
            curentElement = default(T);
            LoadDataFromFile(formatter, userDataFile);
        }
        /// <summary>
        /// Создает новый объект UserDataController на основе переданного пользователя.
        /// 
        /// </summary>
        /// <param name="newUser"></param>
        protected AuxiliaryDataController(string key, T newElement)
        {
            elements = new Dictionary<string, T>();
            elements.Add(key, newElement);
            curentElement = newElement;
        }
        /// <summary>
        /// Загружает данные используя соотвествующий форматтер.
        /// </summary>
        /// <param name="formatter">Форматтер данных.</param>
        /// <param name="file">Файл с данными пользователей.</param>
        public void LoadDataFromFile(IFormatter formatter, FileInfo file)
        {
            using (FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            {
                elements = (Dictionary<string, T>)formatter.Deserialize(stream);
                curentElement = elements.Values.FirstOrDefault(p => p != null);
            }
        }
        /// <summary>
        /// Сохраняет данные спользуя соотвествующий форматтер.
        /// </summary>
        /// <param name="formatter">Форматтер данных</param>
        /// <param name="file">Файл для </param>
        public void SaveDataToFile(IFormatter formatter, FileInfo file)
        {
            using (FileStream stream = new FileStream(file.FullName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                formatter.Serialize(stream, elements);
            }
        }
        /// <summary>
        /// Возвращает объект из справочника, представляющий элемент с заданным признаком.
        /// Возвращет null, если данного элемент не был найден.
        /// </summary>
        /// <param name="value">Значение признака, по которому выполняется индексация.</param>
        /// <returns>Возвращаемый элемент из справочника.</returns>
        abstract public T this[string value]
        { get; }
        /// <summary>
        /// Возвращает текущего выбранный элемент.
        /// </summary>
        /// <returns></returns>
        public T GetCurrentElement()
        {
            return curentElement;
        }
        /// <summary>
        /// Задает новый выбранный элемент из внутренного справочника.
        /// Возвращает true, если элемент был успешно найден и задан, и false в противном случае.
        /// </summary>
        /// <param name="SetCurrentElement">Устанавливаемый элемент.</param>
        /// <returns>Результат установки текущего элемента.</returns>
        public virtual bool SetCurrentElement(string value)
        {
            T tempElement;
            if (elements.TryGetValue(value.ToString(), out tempElement))
            {
                curentElement = tempElement;
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Добавляет новый элемент в справочник.
        /// </summary>
        /// <param name="element">Добавляемый элемент.</param>
        public abstract void AddElement(T element);
        /// <summary>
        /// Удаляет элемент из правочника.
        /// </summary>
        /// <param name="element">Удаляемый элемент.</param>
        public abstract void RemoveElement(T element);

        public int Count
        {
            get { return elements.Count; }
        }
    }
}
