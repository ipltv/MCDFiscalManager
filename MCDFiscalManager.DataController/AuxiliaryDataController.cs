using System.Collections.Generic;

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
        /// <summary>
        /// Менеджер данных, обеспечивающий операции добавления, удаления и обновления.
        /// </summary>
        protected IDataSaver dataManager;
        /// <summary>
        /// Загрузить данные.
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
        protected AuxiliaryDataController() { }
        protected AuxiliaryDataController(IDataSaver saver)
        {
            dataManager = saver;
            elementsList = saver.Load<T>();
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
        /// Добавляет новый элемент в справочник.
        /// </summary>
        /// <param name="element">Добавляемый элемент.</param>
        public virtual void AddElement(T element)
        {
            elementsList.Add(element);
            dataManager.Add<T>(element);
        }
        public virtual void AddRange(ICollection<T> items)
        {
            dataManager.Add<T>(items);
        }
        public virtual void RemoveElement(T element)
        {
            dataManager.Delete<T>(element);
            elementsList = dataManager.Load<T>();
        }
        public virtual void UpdateElement(T element)
        {
            dataManager.Update(element);
            elementsList = dataManager.Load<T>();
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
