namespace task2.DAL.Intefaces
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T> 
        where T : class
    {
        /// <summary>
        /// Получение всех объектов.
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получение одного объекта по id.
        /// </summary>
        T Get(int id);

        /// <summary>
        /// Проверяет наличие объекта.
        /// </summary>
        IEnumerable<T> Find(Func<T, bool> predicate);

        /// <summary>
        /// Создание объекта.
        /// </summary>
        void Create(T item);

        /// <summary>
        /// Обновление объекта.
        /// </summary>
        void Update(T item);

        /// <summary>
        /// Удаление объекта.
        /// </summary>
        void Delete(int id);
    }
}
