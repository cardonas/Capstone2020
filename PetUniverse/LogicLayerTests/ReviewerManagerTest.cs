﻿using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver : Mohamed Elamin , 2/21/2020
    ///
    /// Test the reviewer manager
    /// </summary>
    [TestClass]
    public class ReviewerManagerTest
    {
        private IAdoptionAccessor fakeReviewerAccessor;
        private ReviewerManager reviewerManager;

        /// <summary>
        /// initialize the fakeReviewerAccessor and assgined the reviewer mananger object
        /// to the fake data access, So we can test the reviewer manager without effecting the real DB
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            fakeReviewerAccessor = new FakeReviewerAccessor();
            reviewerManager = new ReviewerManager(fakeReviewerAccessor);
        }

        /// <summary>
        /// Test the RetrieveCustomersFilledQuestionnair method
        /// to pass the test must retrieve 1
        /// (The count of the fake rows on the fake DB)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        [TestMethod]
        public void TestRetrieveCustomersFilledQuestionnair()
        {
            //arrange
            List<AdoptionApplication> adoptionApplications = new List<AdoptionApplication>();

            //Acct
            adoptionApplications = reviewerManager.retrieveCustomersFilledQuestionnair();
            if (adoptionApplications != null)
            {
                Assert.AreEqual(4, adoptionApplications.Count);
            }

        }

        /// <summary>
        /// Test GetCustomerBuyCustomerName method
        /// to pass the test must retrieve "Elamin"
        /// (The value that we assgined to the parameter must match the last name of one
        /// of the Fake customers)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        [TestMethod]
        public void TestGetCustomerByCustomerName()
        {
            //arrange
            AdoptionCustomer customer = null;
            string customerName = "Elamin";

            //acct
            customer = reviewerManager.retrieveCustomerByCustomerName(customerName);
            //assert
            Assert.AreEqual(customerName, customer.LastName);

        }

        /// <summary>
        /// Test  for RetrieveCustomerQuestionnair method
        /// to pass the test must retrieve "10"
        /// (The value that we assgined to the parameter (10000) must match with 10 rows on our fake DB)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 4/2/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        [TestMethod]
        public void TestRetrieveCustomerQuestionnair()
        {
            //arrange
            //List<CustomerQuestionnarVM> customerQuestionnars = new List<CustomerQuestionnarVM>();
            //int customerID = 10000;

            ////acct
            //customerQuestionnars = reviewerManager.retrieveCustomerQuestionnar(customerID);

            ////Assert
            //Assert.AreEqual(10, customerQuestionnars.Count);

        }

        /// <summary>
        /// Test  for SubmitReviewerDecision
        /// to pass the test must retrieve "true"
        /// (That means the status changed to Interviewer)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 2/4/2020
        /// Mohamed Elamin , 2/21/2020
        /// </remarks>
        [TestMethod]
        public void TestSubmitReviewerDecision()
        {
            // bool (int adoptionApplicationID, string decision);
            int adoptionApplicationID = 10000;
            string Reviewerdecision = "Interviewer";
            bool expect = true;
            bool result = reviewerManager.SubmitReviewerDecision(adoptionApplicationID, Reviewerdecision);
            Assert.AreEqual(expect, result);
        }

        /// <summary>
        /// Test  for TestSubmitInterviewerDecision
        /// to pass the test must retrieve "true"
        /// (That means the status changed to InHomeInspection)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 3/3/2020
        /// Mohamed Elamin , 3/4/2020
        /// </remarks>
        [TestMethod]
        public void TestSubmitInterviewerDecision()
        {
            int adoptionApplicationID = 10000;
            string Interviewerdecision = "InHomeInspection";
            bool expect = true;
            bool result = reviewerManager.SubmitReviewerDecision(adoptionApplicationID, Interviewerdecision);
            Assert.AreEqual(expect, result);
        }

        /// <summary>
        /// Test  for TestSubmitDenyDecision
        /// to pass the test must retrieve "true"
        /// (That means the status changed to deny)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 3/3/2020
        /// Mohamed Elamin , 3/4/2020
        /// </remarks>
        [TestMethod]
        public void TestSubmitDenyDecision()
        {
            // bool (int adoptionApplicationID, string decision);
            int adoptionApplicationID = 10000;
            string Denydecision = "Deny";
            bool expect = true;
            bool result = reviewerManager.SubmitReviewerDecision(adoptionApplicationID, Denydecision);
            Assert.AreEqual(expect, result);
        }

        //public bool addAdoptionApplication(MVCAdoptionApplication adoptionApplication)
        /// <summary>
        /// Test  for addAdoptionApplication
        /// to pass the test must retrieve "true"
        /// (That means the application added correctly)
        /// </summary>
        /// <remarks>
        /// by Awaab Elamin 3/3/2020
        /// Mohamed Elamin , 3/4/2020
        /// </remarks>
        [TestMethod]
        public void TestAdoptionApplication()
        {
            MVCAdoptionApplication adoptionApplication = new MVCAdoptionApplication();
            adoptionApplication.AdoptionApplicationID = 10003;
            adoptionApplication.CustomerEmail = "Awaab@PetUnviesal.com";
            adoptionApplication.AnimalID = 10004;
            adoptionApplication.RecievedDate = DateTime.Now;
            adoptionApplication.Status = "Reviewer";
            bool expect = true;
            bool result = reviewerManager.addAdoptionApplication(adoptionApplication);
            Assert.AreEqual(expect, result);
        }


    }
}
