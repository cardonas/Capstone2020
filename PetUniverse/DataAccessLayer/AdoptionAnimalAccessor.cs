﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/5/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Holds the data access methods for the AdoptionAnimalAccessor Class
    /// </summary>
    public class AdoptionAnimalAccessor : IAdoptionAnimalAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/5/2020
        /// Approver: Thomas Dupuy
        /// 
        /// Selects a list of Adoption Animal VMs from the database
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<AdoptionAnimalVM> SelectAdoptionAnimalsByActive(bool active)
        {
            List<AdoptionAnimalVM> adoptionAnimalVMs = new List<AdoptionAnimalVM>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select_adoption_animals_by_active", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Active", active);

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var adoptionAnimalVM = new AdoptionAnimalVM();

                        if(!reader.IsDBNull(0))adoptionAnimalVM.AnimalID = reader.GetInt32(0);
                        if(!reader.IsDBNull(1))adoptionAnimalVM.AnimalName = reader.GetString(1);
                        if(!reader.IsDBNull(2))adoptionAnimalVM.Dob = reader.GetDateTime(2);
                        if(!reader.IsDBNull(3))adoptionAnimalVM.AnimalBreed = reader.GetString(3);
                        if(!reader.IsDBNull(4))adoptionAnimalVM.ArrivalDate = reader.GetDateTime(4);
                        if(!reader.IsDBNull(5))adoptionAnimalVM.CurrentlyHoused = reader.GetBoolean(5);
                        if(!reader.IsDBNull(6))adoptionAnimalVM.Adoptable = reader.GetBoolean(6);
                        if(!reader.IsDBNull(7))adoptionAnimalVM.Active = reader.GetBoolean(7);
                        if(!reader.IsDBNull(8))adoptionAnimalVM.AnimalSpeciesID = reader.GetString(8);
                        if(!reader.IsDBNull(9))adoptionAnimalVM.AnimalKennelID = reader.GetInt32(9);
                        if(!reader.IsDBNull(10))adoptionAnimalVM.AnimalKennelInfo = reader.GetString(10);
                        if(!reader.IsDBNull(11))adoptionAnimalVM.AnimalMedicalInfoID = reader.GetInt32(11);
                        if(!reader.IsDBNull(12))adoptionAnimalVM.IsSpayedorNuetered = reader.GetBoolean(12);
                        if(!reader.IsDBNull(13))adoptionAnimalVM.AdoptionApplicationID = reader.GetInt32(13);
                        if(!reader.IsDBNull(14))adoptionAnimalVM.CustomerID = reader.GetInt32(14);
                        if(!reader.IsDBNull(15))adoptionAnimalVM.UserID = reader.GetInt32(15);
                        if(!reader.IsDBNull(16))adoptionAnimalVM.UserFirstName = reader.GetString(16);
                        if(!reader.IsDBNull(17))adoptionAnimalVM.UserLastName = reader.GetString(17);
                        if(!reader.IsDBNull(18))adoptionAnimalVM.AnimalHandlingNotesID = reader.GetInt32(18);
                        if(!reader.IsDBNull(19))adoptionAnimalVM.AnimalHandlingNotes = reader.GetString(19);
                        if(!reader.IsDBNull(20))adoptionAnimalVM.TempermentWarning = reader.GetString(20);

                        adoptionAnimalVMs.Add(adoptionAnimalVM);
                        

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return adoptionAnimalVMs;
        }
    }
}
