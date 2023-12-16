using Heladeria.Utilities;
using Microsoft.AspNetCore.Mvc;

return View(supplier);
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(SupplierDTO supplier)
{
    if (ModelState.IsValid)
    {
        await _supplierRepository.UpdateAsync(UrlResources.UrlBase + UrlResources.UrlSuppliers + supplier.Id, supplier);
        return RedirectToAction(nameof(Index));
    }

    return View();
}

[HttpDelete]
public async Task<IActionResult> Delete(int id)
{
    var supplier = await _supplierRepository.GetByIdAsync(UrlResources.UrlBase + UrlResources.UrlSuppliers, id);
    if (supplier == null)
    {
        return Json(new { success = false, message = "Proveedor no encontrado." });
    }

    var deleteResult = await _supplierRepository.DeleteAsync(UrlResources.UrlBase + UrlResources.UrlSuppliers, id);
    if (deleteResult)
    {
        return Json(new { success = true, message = "Proveedor eliminado correctamente." });
    }
    else
    {
        return Json(new { success = false, message = "Error al eliminar el proveedor." });
    }
}
    }
}