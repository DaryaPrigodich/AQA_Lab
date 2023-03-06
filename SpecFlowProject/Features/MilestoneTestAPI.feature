@API
Feature: MilestoneTestAPI
Interact with milestones via API

@API
Scenario Outline:  API test milestone
    Given new project with <projectName> name has been created via API
    When user adds milestone <milestoneName> name into last created project
    Then milestone is added 
    When user updates last created milestone name to <updatedMilestone> name 
    Then milestone is updated
    When user deletes last updated milestone
    Then milestone is deleted  
    * project is deleted 
    
    Examples:
      | projectName | milestoneName |  updatedMilestone  | 
      | API Project | API Milestone |  New API Milestone |




  
