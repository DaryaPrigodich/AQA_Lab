@UI
Feature: MilestoneTestUI
Interact with milestones via UI

    Background:
        Given user has logged in

    @UI
    Scenario Outline: 1. Add new milestone
        Given new project with <projectName> name has been created
        * dashboard page with created project has been opened
        When user clicks milestone button on created project with <projectName> name
        * user clicks add milestone button
        * user enters milestone name - <milestoneName>
        * user submits milestone form
        Then milestone <milestoneName> is added 

        Examples:
          | projectName  | milestoneName  |
          | Test Project | Test Milestone |

    @UI
    Scenario Outline: 2. Update milestone
        When user clicks milestone button on created project with <projectName> name
        * user clicks edit milestone button
        * user enters updated milestone name - <updatedName>
        * user submits milestone form
        Then milestone <updatedName> is updated

        Examples:
          | projectName  | updatedName   |
          | Test Project | New Milestone |

    @UI
    Scenario Outline: 3. Delete milestone
        When user clicks milestone button on created project with <projectName> name
        * user clicks delete milestone button
        * user confirms deletion
        Then milestone is deleted from project
        * project with <projectName> name is deleted
       
         Examples:
          | projectName  |   
          | Test Project | 
