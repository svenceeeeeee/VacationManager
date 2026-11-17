using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Data;

namespace VacationManager.Logic
{
    public class TeamService
    {
        private TeamRepository teamRepository = new TeamRepository();

        public DataTable GetAllTeams()
        {
            return teamRepository.GetAllTeams();
        }

        public DataTable GetTeamMembers(int teamId)
        {
            if (teamId <= 0)
            {
                return new DataTable();
            }

            return teamRepository.GetTeamMembers(teamId);
        }

        public DataTable GetTeamProjects(int teamId)
        {
            if (teamId <= 0)
            {
                return new DataTable();
            }

            return teamRepository.GetTeamProjects(teamId);
        }
    }
}
