# Headhunters Candidates Database
# Description

#### This API contains these endpoints: 
* Candidates:
    * Get a Candidate : `GET /api/candidate/{id}`
    * Create a Candidate : `POST /api/candidate`
    ```asd```
    * Apply a Candidate to a Position : `POST /api/candidate/{id}/position/{positionId}`
    * Remove a Candidate from Position : `Delete /api/candidate/{id}/position/{PositionId}`
    * Add a Skill to a Candidate : `POST /api/candidate/{id}`
    * Remove Skill from a Candidate : `Delete /api/candidate/{id/skill/{skillId}`
    * Update a Candidate : `PATCH /api/candidate/{id}`
    * Delete a Candidate : `DELETE /api/candidate`
* Companies:
    * Get a Company : `GET /api/company/{id}`
    * Create a Company : `POST /api/company`
    * Add a Position for a Company : `POST /api/company/{id}/position`
    * Update a Company : `PATCH /api/company/{id}`
    * Delete a Company : `DELETE /api/company/{id}`
* Positions:
    * Get a Position : `GET /api/position/{id}`
    * Add a Skill to a Position : `POST /api/position/{id}/skill`
    * Remove a Skill from a Position : `DELETE /api/position/{id}/skill/{skillId}`
    * Update a Position : `PATCH /api/position/{id}`
    * Delete a Position : `DELETE /api/position/{id}`
* Skills:
    * Get a Skill : `GET /api/skill/{id`
    * Add a Skill : `POST /api/skill`
    * Update a Skill : `PATCH /api/skill/{id}`
    * Delete a Skill : `DELETE /api/skill/{id}`
# Technologies Used
# Installation
# Further Updates