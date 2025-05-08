using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostgresEC2.Data;
using MvcNetCoreAWSPostgresEC2.Models;

namespace MvcNetCoreAWSPostgresEC2.Repositories
{
    public class RepositoryHospitales
    {
        private HospitalContext context;
        public RepositoryHospitales(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await context.Departamentos.FirstOrDefaultAsync(z => z.IdDepartamento == id);
        }

        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento dept = new Departamento
            {
                IdDepartamento = id,
                Nombre = nombre,
                Localidad = localidad
            };

            await context.Departamentos.AddAsync(dept);

            await context.SaveChangesAsync();
        }
    }
}
