﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 03/16/2020
    /// Approver: Steven Cardona
    /// 
    /// Data Access Fake for Accessing Users
    /// </summary>
    public interface IMessagesAccessor
    {

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Logic to get departments like provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>   
        List<string> GetDepartmentsLikeInput(string Input);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Logic to get users like provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        List<string> GetUsersLikeInput(string Input);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Logic to send message
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        bool sendEmail(string content, string subject, int senderID, int recieverID);

    }
}