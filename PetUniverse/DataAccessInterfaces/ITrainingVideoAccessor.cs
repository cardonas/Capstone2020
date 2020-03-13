﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Alex Diers
    /// DATE: 2/6/2020
    /// CHECKED BY: NA
    /// 
    /// Interface for the video accessor
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATED DATE: NA
    /// WHAT WAS CHANGED: NA
    /// </remarks>
    public interface ITrainingVideoAccessor
    {
        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Jordan Lindo
        /// 
        /// used for the creation of a TrainingVideo object
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        int InsertTrainingVideo(TrainingVideo video);


        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Used to select a list of TrainingVideo objects by Employee that needs to view them
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        List<TrainingVideo> SelectTrainingVideosByEmployee();

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Used to update a TrainingVideo object that needs to be changed
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        int UpdateTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: 
        /// 
        /// Activate a video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="videoID"></param>
        /// <returns></returns>
        int DeactivateTrainingVideo(TrainingVideo video);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: 
        /// 
        /// Activate a video
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        int ActivateTrainingVideo(TrainingVideo video);
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: 
        /// 
        /// Find videos based on active state
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        List<TrainingVideo> SelectTrainingVideosByActive(bool active = true);
    }
}
