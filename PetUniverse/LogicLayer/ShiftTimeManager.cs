﻿using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Lane Sandburg
    /// Created: 02/07/2019
    /// Approver: Alex Diers
    /// 
    /// the shift time Manager
    /// </summary>
    public class ShiftTimeManager : IShiftTimeManager
    {
        private IShiftTimeAccessor _shiftTimeAccessor;
        public ShiftTimeManager()
        {
            _shiftTimeAccessor = new ShiftTimeAccessor();
        }

        public ShiftTimeManager(IShiftTimeAccessor shiftTimeAccessor)
        {
            _shiftTimeAccessor = shiftTimeAccessor;
        }


        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/07/2019
        /// Approver: Alex Diers
        /// 
        /// Logic for adding a shift time,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="shiftTime"></param>
        public bool AddShiftTime(PetUniverseShiftTime shiftTime)
        {
            bool result = true;
            try
            {
                result = _shiftTimeAccessor.InsertShiftTime(shiftTime) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ShiftTime not added", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/05/2019
        /// Approver: Kaleb Bachert
        /// 
        /// Logic for Deleteing a shift time,
        /// returns true/false if shift time was added
        /// takes a shiftTimeID as a parameter.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="shiftTime"></param>
        public bool DeleteShiftTime(int shiftTimeID)
        {
            bool result = true;
            try
            {
                result = _shiftTimeAccessor.DeleteShiftTime(shiftTimeID) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ShiftTime not added", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/13/2019
        /// Approver: Alex Diers
        /// 
        /// Logic for adding a editing time,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="newShiftTime"></param>
        /// <param name="oldShiftTime"></param>
        public bool EditShiftTime(PetUniverseShiftTime oldShiftTime, PetUniverseShiftTime newShiftTime)
        {
            bool result = false;
            try
            {
                result = (1 == _shiftTimeAccessor.UpdateShiftTime(oldShiftTime, newShiftTime));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update failed", ex); ;
            }

            return result;
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Created: 02/13/2019
        /// Approver:Alex Diers
        /// 
        /// Logic for retrieveing shift times,
        /// returns true/false if shift time was added
        /// takes a shift time as a parameter.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 

        public List<PetUniverseShiftTime> RetrieveShiftTimes()
        {
            List<PetUniverseShiftTime> shiftTimes = null;

            try
            {
                shiftTimes = _shiftTimeAccessor.SelectAllShiftTimes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ShiftTimes not found", ex);
            }

            return shiftTimes;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver: Chase Schutle
        /// 
        /// This is a method for retrieving shift times by departmentID.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<PetUniverseShiftTime> RetrieveShiftTimesByDepartment(string departmentID)
        {
            try
            {
                return _shiftTimeAccessor.SelectShiftTimeByDepartment(departmentID);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}

