using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Checkpoint.Crm.Core.Models.Base;
using Checkpoint.Crm.Core.Models.Cards;
using Checkpoint.Crm.Core.Models.Dictionaries;
using Checkpoint.Crm.Core.Models.Shared;

namespace Checkpoint.Crm.Core.Models.Customers
{
    /// <summary>
    ///     Клиент
    /// </summary>
    public class Customer : ExternallyIdentifiedModel
    {        
        /// <summary>
        ///     Имя
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        /// <summary>
        ///     Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        ///     Пол
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        ///     Дата рождения
        /// </summary>        
        public DateTime? BirthDate { get; set; }

        /// <summary>
        ///     Код языка предпочтения гостя (в ISO)
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     email-адрес
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     Признак подписки на email-рассылки
        /// </summary>
        public bool AllowEmailContact { get; set; }

        /// <summary>
        ///     Перечень телефонов
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        ///     Временный УРЛ на страницу-досье гостя 
        /// </summary>
        public string ViewUrl { get; set; }
        
        /// <summary>
        ///     Заметки
        /// </summary>
        public string Notes { get; set; }
        
        /// <summary>
        /// Статус клиента (OPEN, CLOSED)
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Профиль, с которым было осуществлено слияние
        /// </summary>
        public string MergedTo { get; set; }
        
        /// <summary>
        ///     Карты, привязанные к гостю
        /// </summary>
        public Card[] Cards { get; set; }

        #region Address
        /// <summary>
        ///     Корпус или строение
        /// </summary>
        public string BuildingNo;

        /// <summary>
        ///     Город
        /// </summary>
        public string City;

        /// <summary>
        ///     Код страны
        /// </summary>
        public string CountryCode;

        /// <summary>
        ///     Название страны
        /// </summary>
        public string CountryName;

        /// <summary>
        ///     Район
        /// </summary>
        public string District;

        /// <summary>
        ///     Квартира
        /// </summary>
        public string FlatNo;

        /// <summary>
        ///     № дома
        /// </summary>
        public string HouseNo;

        /// <summary>
        ///     Область
        /// </summary>
        public string Region;

        /// <summary>
        ///     Номер комнаты
        /// </summary>
        public string RoomNo;

        /// <summary>
        ///     Тип поселения (город, село, деревня и т.п.)
        /// </summary>
        public string SettlementType;

        /// <summary>
        ///     Улица
        /// </summary>
        public string Street;

        /// <summary>
        ///     Индекс
        /// </summary>
        public string ZipCode { get; set; }
        
        /// <summary>
        ///     Адрес одной строкой
        /// </summary>
        public string RawAddress { get; set; }
        #endregion
        
        #region Document
        /// <summary>
        ///     Тип документа
        /// </summary>
        public string DocType { get; set; }

        /// <summary>
        ///     Серия
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        ///     Номер
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        ///     Код подразделения
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        ///     Наименование подразделения
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        ///     Дата выдачи
        /// </summary>
        public DateTime? DocIssueDate { get; set; }


        /// <summary>
        ///     Дата окончания действия
        /// </summary>
        public DateTime? DocExpirationDate { get; set; }

        /// <summary>
        ///     Кем выдан
        /// </summary>
        public string DocIssuerInfo { get; set; }
        #endregion

        /// <summary>
        ///     Полное имя гостя
        /// </summary>
        public string FullName => (FirstName + " " + MiddleName + " " + LastName).Trim(' ');
    }
}