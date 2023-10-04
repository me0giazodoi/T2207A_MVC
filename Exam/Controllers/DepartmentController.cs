using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using YourNamespace.Models;

namespace Exam.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly YourDbContext _context;

		public DepartmentController(YourDbContext context)
		{
			_context = context;
		}

		// GET: Department
		public async Task<IActionResult> Index()
		{
			var departments = await _context.Departments.ToListAsync();
			return View(departments);
		}

		// GET: Department/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Department/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("DepartmentName,Location")] Department department)
		{
			if (ModelState.IsValid)
			{
				_context.Add(department);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(department);
		}

		// GET: Department/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var department = await _context.Departments.FindAsync(id);
			if (department == null)
			{
				return NotFound();
			}
			return View(department);
		}

		// POST: Department/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentName,Location")] Department department)
		{
			if (id != department.DepartmentId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(department);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!DepartmentExists(department.DepartmentId))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(department);
		}

		// GET: Department/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var department = await _context.Departments
				.FirstOrDefaultAsync(m => m.DepartmentId == id);
			if (department == null)
			{
				return NotFound();
			}

			return View(department);
		}

		// POST: Department/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var department = await _context.Departments.FindAsync(id);
			_context.Departments.Remove(department);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool DepartmentExists(int id)
		{
			return _context.Departments.Any(e => e.DepartmentId == id);
		}
	}
}
