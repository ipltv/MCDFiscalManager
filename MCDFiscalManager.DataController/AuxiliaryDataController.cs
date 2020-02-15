using MCDFiscalManager.DataController.Savers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace MCDFiscalManager.DataController
{
    /// <summary>
    /// Базовый класс для контроллеров различных вспомогательных данных (компании, ОФД, пользователи).
    /// Это абстрактный класс.
    /// </summary>
    public abstract class AuxiliaryDataController<T> where T: class
    {

        /// <summary>
        /// Список представляющий коллекцию загруженных элементов (пользователь, ОФД и т.д.).
        /// </summary>      
        protected List<T> elementsList;
        protected IDataSaver dataManager = new DataBaseSaver();
        /// <summary>
        /// Текущий элемент.
        /// </summary>
        protected T curentElement;
        /// <summary>
        /// Сохранить данные из списка.
        /// </summary>
        /// <returns></returns>
        protected bool Save()
        {
            try
            {
                dataManager.Save<T>(elementsList);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Загрузить данные из списка.
        /// </summary>
        /// <returns></returns>
        protected bool Load()
        {
            try
            {
                elementsList = dataManager.Load<T>();
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Базовый конструктор, который создает контроллер путем извлечения данных о пользователях из файла с помощью соотвествующего форматера.
        /// Если данные из файла не удается прочитать, будет задано значение по умолчанию.
        /// </summary>
        /// <param name="formatter">Форматер для десериализации данных из файла.</param>
        /// <param name="userDataFile">Файл с данными о пользователях.</param>
        protected AuxiliaryDataController()
        {
            Load();
            curentElement = elementsList.FirstOrDefault();
        }
        /// <summary>
        /// Создает новый объект UserDataController на основе переданного пользователя.
        /// 
        /// </summary>
        /// <param name="newUser"></param>
        protected AuxiliaryDataController(T newElement)
        {
            elementsList = new List<T>();
            elementsList.Add(newElement);
            curentElement = newElement;
        }
        /// <summary>
        /// Загружает данные.
        /// </summary>
        public void LoadData()
        {
            Load();
            curentElement = elementsList.First();
        }
        /// <summary>
        /// Сохраняет данные.
        /// </summary>
        public void SaveData()
        {
            Save();
        }
        /// <summary>
        /// Возвращает объект из справочника, представляющий элемент с заданным признаком.
        /// Возвращет null, если данного элемент не был найден.
        /// </summary>
        /// <param name="value">Значение признака, по которому выполняется индексация.</param>
        /// <returns>Возвращаемый элемент из справочника.</returns>
        virtual public T this[int value]
        {
            get
            {
                try
                {
                    return elementsList[value];

                }
                catch
                {
                    return default(T);
                }
            }
        }
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
        public abstract bool SetCurrentElement(string value);
        public virtual bool SetCurrentElement(T element)
        {
            T item = elementsList.Find(t => t == element);
            if (item != null)
            {
                curentElement = item;
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Добавляет новый элемент в справочник.
        /// </summary>
        /// <param name="element">Добавляемый элемент.</param>
        public virtual void AddElement(T element)
        {
            elementsList.Add(element);
            Save();
        }
        /// <summary>
        /// Удаляет элемент из правочника.
        /// </summary>
        /// <param name="element">Удаляемый элемент.</param>
        public virtual void RemoveElement(T element)
        {
            if (element == curentElement) { curentElement = elementsList.FirstOrDefault(t => t != element); }
            elementsList.Remove(element);
            Save();
        }
        public int Count
        {
            get { return elementsList.Count; }
        }
        public IList<T> Elements
        {
            get { return elementsList.AsReadOnly(); }
        }
    }
}
