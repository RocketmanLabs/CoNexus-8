using System;
/* CoNexus:
 * Membership
 *      Members
 *      Contacts
 *      Organizations
 *      ContactInfo
 * Licensing
 *      IndividualLicences
 * Inquiry Setup
 *      Inquiries
 *      ProcessLibrary, ProcessSteps, templates
 *      ScaleLibrary
 * Inquiry data acquisition:
 *      Statements
 *      Stim Lists
 *      TopicLists
 * Inquiry Evaluation
 * Results
 *      Matrix, _MatrixCell
 *      
 * (contains Members, Processes, and libraries for the storage and reuse of Step templates)
 *      List members
 *      Search members
 *      List processes
 *      Search processes
 *      List evals
 *      Search evals
 *      Contribute to library
 *      Remove from library
 */

/* MemberService:       // Members contain an Inquiry collection and Contact collection
 * (contains Inquiries and Contacts) 
 *      List participants in Inquiry.Group
 *      Search participants in Inquiry.Group
 *      Create member and use PeopleServer to create the key contacts
 *      Edit licensing terms
 *      Edit member record
 *      Enable/Disable member
 */

// Licensing thoughts:
//      To be a facilitator you must have completed the training and have conducted some sessions.
//      The license code must reflect fac status + access to Processes
//              Estimated capacity: +1 for facilitation training
//                                  +1 for CST-Group
//                                  +1 for CST-Individual
//                                  +2 for Pairs voting
//                                  +8 for Rate voting
//                                  +1 for direct voting
//                                  +8 mulch (demographics) 
//                                  +4 risk/csa
//                                  +1 system matrix
//                                  +1 balance matrix
//                                  +1 selection matrix
//                                 ====
//                                  
//      Frex: license code is made up of licensettes:
//              Licensesette: Unique code for product/skill, renewal date or "" for perpetual


/* ProcessService:      // Process and their steps organize resources for the fac
 *      Create process
 *      Edit process properties
 *      Edit licensing terms
 *      Create process step
 *      Edit step properties
 *      ? Simulate process execution
 *      Delete step
 *      Delete process
 */

/* InquiryService:
 *      Create Inquiry
 *      Fetch Inquiry
 *      Configure Inquiry
 *      Open/Close Inquiry
 *      Archive Inquiry
 *      Delete Inquiry
 */

/* PeopleService:
 *      Contact account creation (diff access managed by licensing + biz rules), incl. facs
 *      Contact account edit
 *      Contact account remove
 *      Fetch contact
 *      List contacts
 *      Enter contacts
 *      Search contacts
 *      Edit contact
 *      Remove contact
 *      
 *      Create Inquiry Group
 *      Edit invitation email (DocMgrService, later)
 *      Parse invitation reply (can create Participant)
 *      Create Participant from Contact
 *      Enable/Disable participation
 */

/*
 * MatrixService:
 *      Evaluation support; tracks filled-in cells
 */      