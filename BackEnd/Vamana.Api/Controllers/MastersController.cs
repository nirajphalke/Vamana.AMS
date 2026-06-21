using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vamana.AMS.Api.Controllers.Students;
using Vamana.AMS.Core.Entities.Masters;
using Vamana.AMS.Core.Interfaces;
using Vamana.AMS.Core.Models.Masters;

namespace Vamana.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MasterController : ControllerBase
{
    const int USERID = 1;
    const int ORGANIZATIONID = 1;
    const string MACADDRESS = "00-14-22-01-23-45";
    const string IPADDRESS = "";
    private readonly ILogger<StudentController> _logger;
    private readonly IMasterRepository<AdmissionBatchMaster> _admBatchRepo;
    private readonly IMasterRepository<AdmissionCategoryMaster> _admCategoryRepo;
    private readonly IMasterRepository<AdmissionThroughMaster> _admThroughRepo;
    private readonly IMasterRepository<AdmissionTypeMaster> _admTypeRepo;
    private readonly IMasterRepository<AdmissionYearMaster> _admYearRepo;
    private readonly IMasterRepository<BloodGroupMaster> _bloodGrpRepo;
    private readonly IMasterRepository<BranchMaster> _branchRepo;
    private readonly IMasterRepository<CasteMaster> _casteRepo;
    //private readonly IMasterRepository<CategoryMaster> _categoryRepo;
    private readonly IMasterRepository<CityMaster> _cityRepo;
    private readonly IMasterRepository<CountryMaster> _countryRepo;
    private readonly IMasterRepository<DegreeMaster> _degreeRepo;
    private readonly IMasterRepository<DistrictMaster> _districtRepo;
    private readonly IMasterRepository<GenderMaster> _genderRepo;
    private readonly IMasterRepository<InstituteMaster> _instituteRepo;
    private readonly IMasterRepository<NationalityMaster> _nationalityRepo;
    //private readonly IMasterRepository<OrganizationMaster> _organizationRepo;
    private readonly IMasterRepository<PaymentTypeMaster> _paymentTypeRepo;
    private readonly IMasterRepository<ReceiptTypeMaster> _receiptTypeRepo;
    private readonly IMasterRepository<ReceiptCodeMaster> _receiptCodeRepo;
    private readonly IMasterRepository<ReceiptBelongsToMaster> _receiptBelongsRepo;
    private readonly IMasterRepository<ScholarshipModeMaster> _schModeRepo;
    private readonly IMasterRepository<ScholarshipTypeMaster> _schTypeRepo;
    private readonly IMasterRepository<SemesterMaster> _semesterRepo;
    private readonly IMasterRepository<SessionMaster> _sessionRepo;
    private readonly IMasterRepository<StateMaster> _stateRepo;
    private readonly IMasterRepository<InstallmentTypeMaster> _installmentTypeRepo;
    Stopwatch stopwatch = new Stopwatch();


    public MasterController(
        ILogger<StudentController> logger,
        IMasterRepository<AdmissionBatchMaster> admBatchRepo,
        IMasterRepository<AdmissionCategoryMaster> admCategoryRepo,
        IMasterRepository<AdmissionThroughMaster> admThroughRepo,
        IMasterRepository<AdmissionTypeMaster> admTypeRepo,
        IMasterRepository<AdmissionYearMaster> admYearRepo,
        IMasterRepository<BloodGroupMaster> bloodGrpRepo,
        IMasterRepository<BranchMaster> branchRepo,
        IMasterRepository<CasteMaster> casteRepo,
        IMasterRepository<CategoryMaster> categoryRepo,
        IMasterRepository<CityMaster> cityRepo,
        IMasterRepository<CountryMaster> countryRepo,
        IMasterRepository<DegreeMaster> degreeRepo,
        IMasterRepository<DistrictMaster> districtRepo,
        IMasterRepository<GenderMaster> genderRepo,
        IMasterRepository<InstituteMaster> instituteRepo,
        IMasterRepository<NationalityMaster> nationalityRepo,
        //IMasterRepository<OrganizationMaster> organizationRepo,
        IMasterRepository<PaymentTypeMaster> paymentTypeRepo,
        IMasterRepository<ReceiptTypeMaster> receiptTypeRepo,
        IMasterRepository<ReceiptCodeMaster> receiptCodeRepo,
        IMasterRepository<ReceiptBelongsToMaster> receiptBelongsRepo,
        IMasterRepository<ScholarshipModeMaster> schModeRepo,
        IMasterRepository<ScholarshipTypeMaster> schTypeRepo,
        IMasterRepository<SemesterMaster> semesterRepo,
        IMasterRepository<SessionMaster> sessionRepo,
        IMasterRepository<StateMaster> stateRepo,
        IMasterRepository<InstallmentTypeMaster> installmentTypeRepo)
    {
        _logger = logger;
        _admBatchRepo = admBatchRepo;
        _admCategoryRepo = admCategoryRepo;
        _admThroughRepo = admThroughRepo;
        _admTypeRepo = admTypeRepo;
        _admYearRepo = admYearRepo;
        _bloodGrpRepo = bloodGrpRepo;
        _branchRepo = branchRepo;
        _casteRepo = casteRepo;
        //_categoryRepo = categoryRepo;
        _cityRepo = cityRepo;
        _countryRepo = countryRepo;
        _degreeRepo = degreeRepo;
        _districtRepo = districtRepo;
        _genderRepo = genderRepo;
        _instituteRepo = instituteRepo;
        _nationalityRepo = nationalityRepo;
        //_organizationRepo = organizationRepo;
        _paymentTypeRepo = paymentTypeRepo;
        _receiptTypeRepo = receiptTypeRepo;
        _receiptCodeRepo = receiptCodeRepo;
        _receiptBelongsRepo = receiptBelongsRepo;
        _schModeRepo = schModeRepo;
        _schTypeRepo = schTypeRepo;
        _semesterRepo = semesterRepo;
        _sessionRepo = sessionRepo;
        _stateRepo = stateRepo;
        _installmentTypeRepo = installmentTypeRepo;
    }

    [HttpGet("lookup/{master}")]
    public async Task<IActionResult> GetLookUp([FromRoute] string master, bool forceRefresh)
    {
        stopwatch.Start();
        _logger.LogInformation($"GET request received for MasterController:GetLookUp for master {master}");
        var key = master.ToLowerInvariant();
        IEnumerable<object>? result = key switch
        {
            "admissionbatch" => await _admBatchRepo.GetLookupAsync(c => new { id = c.AdmissionBatchId, text = c.AdmissionBatchName }, forceRefresh),
            "admissioncategory" => await _admCategoryRepo.GetLookupAsync(c => new { id = c.AdmissionCategoryId, text = c.AdmissionCategoryName }, forceRefresh),
            "admissionthrough" => await _admThroughRepo.GetLookupAsync(c => new { id = c.AdmissionThroughId, text = c.AdmissionThroughName }, forceRefresh),
            "admissiontype" => await _admTypeRepo.GetLookupAsync(c => new { id = c.AdmissionTypeId, text = c.AdmissionTypeName }, forceRefresh),
            "admissionyear" => await _admYearRepo.GetLookupAsync(c => new { id = c.AdmissionYearId, text = c.AdmissionYearName }, forceRefresh),
            "bloodgroup" => await _bloodGrpRepo.GetLookupAsync(c => new { id = c.BloodGroupId, text = c.BloodGroupName }, forceRefresh),
            "branch" => await _branchRepo.GetLookupAsync(c => new { id = c.BranchId, text = c.BranchCode }, forceRefresh),
            "caste" => await _casteRepo.GetLookupAsync(c => new { id = c.CasteId, text = c.CasteName } , forceRefresh ),
            //"category" => await _categoryRepo.GetLookupAsync(c => new { id = c.CategoryId, text = c.CategoryLongName }),
            "city" => await _cityRepo.GetLookupAsync(c => new { id = c.CityId, text = c.CityName }, forceRefresh),
            "country" => await _countryRepo.GetLookupAsync(c => new { id = c.CountryId, text = c.CountryName }, forceRefresh),
            "degree" => await _degreeRepo.GetLookupAsync(c => new { id = c.DegreeId, text = c.DegreeCode }, forceRefresh),
            "district" => await _districtRepo.GetLookupAsync(c => new { id = c.DistrictId, text = c.DistrictName }, forceRefresh),
            "gender" => await _genderRepo.GetLookupAsync(c => new { id = c.GenderId, text = c.GenderName }, forceRefresh),
            "institute" => await _instituteRepo.GetLookupAsync(c => new { id = c.InstituteId, text = c.InstituteName }, forceRefresh),
            "nationality" => await _nationalityRepo.GetLookupAsync(c => new { id = c.NationalityId, text = c.NationalityName }, forceRefresh),
            "paymenttype" => await _paymentTypeRepo.GetLookupAsync(c => new { id = c.PaymentTypeId, text = c.PaymentTypeName }, forceRefresh),
            "receipttype" => await _receiptTypeRepo.GetLookupAsync(c => new { id = c.ReceiptTypeId, text = c.ReceiptTypeName }, forceRefresh),
            "receiptcode" => await _receiptCodeRepo.GetLookupAsync(c => new { id = c.ReceiptCodeId, text = c.ReceiptCodeName }, forceRefresh),
            "receiptbelongsto" => await _receiptBelongsRepo.GetLookupAsync(c => new { id = c.ReceiptBelongsToId, text = c.ReceiptBelongsToName}, forceRefresh),
            "scholarshipmode" => await _schModeRepo.GetLookupAsync(c => new { id = c.ScholarshipModeId, text = c.ScholarshipModeName }, forceRefresh),
            "scholarshiptype" => await _schTypeRepo.GetLookupAsync(c => new { id = c.ScholarshipTypeId, text = c.ScholarshipTypeName }, forceRefresh),
            "semester" => await _semesterRepo.GetLookupAsync(c => new { id = c.SemesterId, text = c.SemesterShortName }, forceRefresh),
            "session" => await _sessionRepo.GetLookupAsync(c => new { id = c.SessionId, text = c.SessionName }, forceRefresh),
            "state" => await _stateRepo.GetLookupAsync(c => new { id = c.StateId, text = c.StateName }, forceRefresh),
            "installmenttype" => await _installmentTypeRepo.GetLookupAsync(c => new { id = c.InstallmentTypeId, text = c.InstallmentTypeName}, forceRefresh),
            _ => null
        };


        if (result == null)
            return BadRequest("Invalid master type");

        _logger.LogInformation($"MasterController:GetLookUp for master {master} Completed in {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Stop();
        return Ok(result);
    }


    //[HttpGet("lookup1/{master}")]
    //public async Task<IActionResult> GetLookUp1([FromRoute] string master)
    //{
    //    var lookups = new Dictionary<string, Func<Task<IEnumerable<object>>>>
    //    {
    //        ["admissionbatch"] = async () =>
    //        {
    //            var batches = await _admissionBatchRepo.GetAllAsync();
    //            return batches.Select(ab => new { id = ab.AdmissionBatchId, text = ab.AdmissionBatchName });
    //        },
    //        ["category"] = async () =>
    //        {
    //            var categories = await _categoryRepo.GetAllAsync();
    //            return categories.Select(c => new { id = c.CategoryId, text = c.CategoryLongName });
    //        },
    //        ["caste"] = async () =>
    //        {
    //            var castes = await _casteRepo.GetAllAsync();
    //            return castes.Select(c => new { id = c.CasteId, text = c.CasteName });
    //        },
    //        ["country"] = async () =>
    //        {
    //            var countries = await _countryRepo.GetAllAsync();
    //            return countries.Select(c => new { id = c.CountryId, text = c.CountryName });
    //        },
    //        ["nationality"] = async () =>
    //        {
    //            var nationalities = await _nationalityRepo.GetAllAsync();
    //            return nationalities.Select(n => new { id = n.NationalityId, text = n.NationalityName });
    //        },
    //        ["religion"] = async () =>
    //        {
    //            var religions = await _religionRepo.GetAllAsync();
    //            return religions.Select(r => new { id = r.ReligionId, text = r.ReligionName });
    //        },
    //        ["bloodgroup"] = async () =>
    //        {
    //            var bloodGroups = await _bloodGroupRepo.GetAllAsync();
    //            return bloodGroups.Select(bg => new { id = bg.BloodGroupId, text = bg.BloodGroupName });
    //        },
    //        ["state"] = async () =>
    //        {
    //            var states = await _stateRepo.GetAllAsync();
    //            return states.Select(s => new { id = s.StateId, text = s.StateName });
    //        },
    //        // ➕ Add more masters here as needed

    //    };

    //    if (!lookups.TryGetValue(master.ToLowerInvariant(), out var lookupFn))
    //        return BadRequest("Invalid master type");

    //    var result = await lookupFn();
    //    return Ok(result);
    //}


    [HttpGet("admissioncategory")]
    public async Task<ActionResult<IEnumerable<AdmissionCategoryMasterModel>>> GetCategories([FromQuery] bool forceRefresh = false)
    {
        var categories = await _admCategoryRepo.GetAllAsync(forceRefresh);
        var result = categories.Select(c => new CategoryMasterModel
        {
            CategoryId = c.AdmissionCategoryId,
            CategoryName = c.AdmissionCategoryName,
            CategoryLongName = c.AdmissionCategoryLongName,
            IsActive = c.IsActive,
            CreatedBy = c.CreatedBy,
            CreatedDate = c.CreatedDate,
            ModifiedBy = c.ModifiedBy,
            ModifiedDate = c.ModifiedDate ?? default,
            IPAddress = c.IPAddress ?? string.Empty,
            OrganizationId = c.OrganizationId
        }).ToList();

        return Ok(result);
    }


    [HttpGet("admissioncategory/{id}")]
    public async Task<ActionResult<IEnumerable<CategoryMasterModel>>> GetCategoryById(int id) =>
       Ok(await _admCategoryRepo.GetByIdAsync(id));

    [HttpPost("admissioncategory")]
    public async Task<ActionResult> AddCategory(CategoryMasterModel category)
    {
        // Check for unique constraint violation
        var duplicateCategory = (await _admCategoryRepo.GetAllAsync(true))
            .FirstOrDefault(c => c.AdmissionCategoryName.ToLower() == category.CategoryName.ToLower() || c.AdmissionCategoryLongName.ToLower() == category.CategoryLongName.ToLower());

        if (duplicateCategory != null)
        {
            return Conflict($"A category with the same short name or long name already exists (ID: {duplicateCategory.AdmissionCategoryName} - {duplicateCategory.AdmissionCategoryName}).");
        }

        var categoryMst = new AdmissionCategoryMaster
        {
            AdmissionCategoryId = category.CategoryId,
            AdmissionCategoryName = category.CategoryName,
            AdmissionCategoryLongName = category.CategoryLongName,
            IsActive = category.IsActive,
            CreatedBy  = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = category.IPAddress,
            OrganizationId = ORGANIZATIONID
        };
        await _admCategoryRepo.AddAsync(categoryMst);
        await _admCategoryRepo.SaveAsync();
        return CreatedAtAction(nameof(GetCategories), new { id = category.CategoryId }, category);
    }

    [HttpPut("admissioncategory/{id}")]
    public async Task<ActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryMasterModel category)
    {
        var existingRec = await _admCategoryRepo.GetByIdAsync(id);
        if (existingRec == null)
        {
            return NotFound($"Category with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicateCategory = (await _admCategoryRepo.GetAllAsync(true))
            .FirstOrDefault(c =>
                (c.AdmissionCategoryName.ToLower() == category.CategoryName.ToLower() || c.AdmissionCategoryLongName.ToLower() == category.CategoryLongName.ToLower())
                && c.AdmissionCategoryId != id);

        if (duplicateCategory != null)
        {
            return Conflict($"A category with the same short name or long name already exists (ID: {duplicateCategory.AdmissionCategoryName} - {duplicateCategory.AdmissionCategoryName}).");
        }

        // Update the existing record
        existingRec.AdmissionCategoryName = category.CategoryName;
        existingRec.AdmissionCategoryLongName = category.CategoryLongName;
        existingRec.IsActive = category.IsActive;
        existingRec.ModifiedBy  = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = category.IPAddress;

        _admCategoryRepo.Update(existingRec);
        await _admCategoryRepo.SaveAsync();
        return NoContent();
    }

    [HttpGet("caste")]
    public async Task<ActionResult<IEnumerable<CasteMasterModel>>> GetCastes([FromQuery] bool forceRefresh = false)
    {
        var castes = await _casteRepo.GetAllAsync(forceRefresh);

        var result = castes
        .Cast<CasteMaster>() // since repo returns IEnumerable<T>
        .Select(c => new CasteMasterModel
        {
            CasteId = c.CasteId,
            CasteName = c.CasteName,
            CategoryId = c.CategoryId,
            //CategoryName = c.Category.CategoryShortName,
			IsActive = c.IsActive
        })
        .ToList();

        return Ok(result);
    }

    [HttpGet("caste/{id}")]
    public async Task<ActionResult<IEnumerable<CasteMasterModel>>> GetCasteById(int id) =>
       Ok(await _casteRepo.GetByIdAsync(id));

    [HttpPost("caste")]
    public async Task<ActionResult> AddCaste(CasteMasterModel caste)
    {
        // Check for unique constraint violation
        var duplicateCaste = (await _casteRepo.GetAllAsync(true))
            .FirstOrDefault(c =>
                c.CasteName.ToLower() == caste.CasteName.ToLower());

        if (duplicateCaste != null)
        {
            return Conflict($"A caste with the same name already exists (ID: {duplicateCaste.CasteName}).");
        }

        var casteMst = new CasteMaster
        {
            CategoryId = caste.CategoryId,
            CasteName = caste.CasteName,
            IsActive = caste.IsActive,
            CreatedBy = caste.CreatedBy,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = caste.IPAddress,
            OrganizationId = caste.OrganizationId,
            MACAddress = caste.MACAddress
        };
        await _casteRepo.AddAsync(casteMst);
        await _casteRepo.SaveAsync();
        return CreatedAtAction(nameof(GetCastes), new { id = caste.CasteId }, caste);
    }

    [HttpPut("caste/{id}")]
    public async Task<ActionResult> UpdateCaste([FromRoute] int id, [FromBody] CasteMasterModel caste)
    {
        var existingRec = await _casteRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"Caste with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicateCaste = (await _casteRepo.GetAllAsync(true))
            .FirstOrDefault(c =>
                (c.CasteName.ToLower() == caste.CasteName.ToLower())
                && c.CasteId != id);

        if (duplicateCaste != null)
        {
            return Conflict($"A caste with the same name already exists (ID: {duplicateCaste.CasteName}).");
        }

        existingRec.CasteName = caste.CasteName;
        existingRec.CategoryId = caste.CategoryId;
        existingRec.IsActive = caste.IsActive;
        existingRec.ModifiedBy  = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = caste.IPAddress;

        _casteRepo.Update(existingRec);
        await _casteRepo.SaveAsync();
        return NoContent();
    }

    [HttpGet("nationality")]
    public async Task<ActionResult<IEnumerable<NationalityMasterModel>>> GetNationalities([FromQuery] bool forceRefresh = false) =>
      Ok(await _nationalityRepo.GetAllAsync(forceRefresh));


    [HttpGet("nationality/{id}")]
    public async Task<ActionResult<IEnumerable<NationalityMasterModel>>> GetNationalityById(int id) =>
       Ok(await _nationalityRepo.GetByIdAsync(id));

    [HttpPost("nationality")]
    public async Task<ActionResult> AddNationality(NationalityMasterModel nationality)
    {
        // Check for unique constraint violation
        var duplicateNationality = (await _nationalityRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                c.NationalityName.ToLower() == nationality.NationalityName.ToLower());

        if (duplicateNationality != null)
        {
            return Conflict($"A nationality with the name already exists (ID: {duplicateNationality.NationalityName}).");
        }

        var nationalityMst = new NationalityMaster
        {
            NationalityId = nationality.NationalityId,
            NationalityName = nationality.NationalityName,
            IsActive = nationality.IsActive,
            CreatedBy  = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = nationality.IPAddress,
            MACAddress = nationality.MACAddress,
            OrganizationId = ORGANIZATIONID
        };
        await _nationalityRepo.AddAsync(nationalityMst);
        await _nationalityRepo.SaveAsync();
        return CreatedAtAction(nameof(GetNationalities), new { id = nationality.NationalityId }, nationality);
    }

    [HttpPut("nationality/{id}")]
    public async Task<ActionResult> UpdateNationality([FromRoute] int id, [FromBody] NationalityMasterModel nationality)
    {
        var existingRec = await _nationalityRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"Nationality with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicateNationality = (await _nationalityRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                (c.NationalityName.ToLower() == nationality.NationalityName.ToLower())
                && c.NationalityId != nationality.NationalityId);

        if (duplicateNationality != null)
        {
            return Conflict($"A nationality with the name already exists (ID: {duplicateNationality.NationalityName}).");
        }

        existingRec.NationalityName = nationality.NationalityName;
        existingRec.IsActive = nationality.IsActive;
        existingRec.ModifiedBy  = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = nationality.IPAddress;

        _nationalityRepo.Update(existingRec); // Use the updated object
        await _nationalityRepo.SaveAsync();
        return NoContent();
    }

    //[HttpGet("bloodGroup")]
    //public async Task<ActionResult<IEnumerable<ReligionMasterModel>>> GetBloodGroups() =>
    //Ok(await _bloodGrpRepo.GetAllAsync());

    [HttpGet("bloodGroup")]
    public async Task<ActionResult<IEnumerable<ReligionMasterModel>>> GetBloodGroups([FromQuery] bool forceRefresh = false) =>
    Ok(await _bloodGrpRepo.GetAllAsync(forceRefresh));

    [HttpGet("bloodGroup/{id}")]
    public async Task<ActionResult<IEnumerable<BloodGroupMasterModel>>> GetBloodGroupById(int id) =>
       Ok(await _bloodGrpRepo.GetByIdAsync(id));

    [HttpPost("bloodGroup")]
    public async Task<ActionResult> AddBloodGroup(BloodGroupMasterModel bloodGroup)
    {
        // Check for unique constraint violation
        var duplicateBloodGroup = (await _bloodGrpRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                c.BloodGroupName.ToLower() == bloodGroup.BloodGroupName.ToLower());

        if (duplicateBloodGroup != null)
        {
            return Conflict($"A blood group with the name already exists (ID: {duplicateBloodGroup.BloodGroupName}).");
        }

        var bloodGroupMst = new BloodGroupMaster
        {
            BloodGroupId = bloodGroup.BloodGroupId,
            BloodGroupName = bloodGroup.BloodGroupName,
            IsActive = bloodGroup.IsActive,
            CreatedBy  = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = bloodGroup.IPAddress,
            MACAddress = bloodGroup.MACAddress,
            OrganizationId = ORGANIZATIONID
        };
        await _bloodGrpRepo.AddAsync(bloodGroupMst);
        await _bloodGrpRepo.SaveAsync();
        return CreatedAtAction(nameof(GetBloodGroups), new { id = bloodGroup.BloodGroupId }, bloodGroup);
    }

    [HttpPut("bloodGroup/{id}")]
    public async Task<ActionResult> UpdateBloodGroup([FromRoute] int id, [FromBody] BloodGroupMasterModel bloodGroup)
    {
        var existingRec = await _bloodGrpRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"BloodGroup with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicateBloodGroup = (await _bloodGrpRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                (c.BloodGroupName.ToLower() == bloodGroup.BloodGroupName.ToLower())
                && c.BloodGroupId != bloodGroup.BloodGroupId);

        if (duplicateBloodGroup != null)
        {
            return Conflict($"A blood group with the name already exists (ID: {duplicateBloodGroup.BloodGroupName}).");
        }

        existingRec.BloodGroupName = bloodGroup.BloodGroupName;
        existingRec.IsActive = bloodGroup.IsActive;
        existingRec.ModifiedBy  = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = bloodGroup.IPAddress;

        _bloodGrpRepo.Update(existingRec); // Use the updated object
        await _bloodGrpRepo.SaveAsync();
        return NoContent();
    }

    [HttpGet("admissionBatch")]
    public async Task<ActionResult<IEnumerable<AdmissionBatchMasterModel>>> GetAdmissionBatchs([FromQuery] bool forceRefresh = false) =>
        Ok(await _admBatchRepo.GetAllAsync(forceRefresh));

    [HttpGet("admissionBatch/{id}")]
    public async Task<ActionResult<IEnumerable<AdmissionBatchMasterModel>>> GetAdmissionBatchById(int id) =>
       Ok(await _admBatchRepo.GetByIdAsync(id));

    [HttpPost("admissionBatch")]
    public async Task<ActionResult> AddAdmissionBatch(AdmissionBatchMasterModel admissionBatch)
    {
        // Check for unique constraint violation
        var duplicateAdmissionBatch = (await _admBatchRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                c.AdmissionBatchName.ToLower() == admissionBatch.AdmissionBatchName.ToLower());

        if (duplicateAdmissionBatch != null)
        {
            return Conflict($"A admission batch with the name already exists (ID: {duplicateAdmissionBatch.AdmissionBatchName}).");
        }

        var admissionBatchMst = new AdmissionBatchMaster
        {
            AdmissionBatchId = admissionBatch.AdmissionBatchId,
            AdmissionBatchName = admissionBatch.AdmissionBatchName,
            IsActive = admissionBatch.IsActive,
            CreatedBy  = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = admissionBatch.IPAddress,
            MACAddress = admissionBatch.MACAddress,
            OrganizationId = ORGANIZATIONID
        };
        await _admBatchRepo.AddAsync(admissionBatchMst);
        await _admBatchRepo.SaveAsync();
        return CreatedAtAction(nameof(GetAdmissionBatchs), new { id = admissionBatch.AdmissionBatchId }, admissionBatch);
    }

    [HttpPut("admissionBatch/{id}")]
    public async Task<ActionResult> UpdateAdmissionBatch([FromRoute] int id, [FromBody] AdmissionBatchMasterModel admissionBatch)
    {
        var existingRec = await _admBatchRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"Admission Batch with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicateAdmissionBatch = (await _admBatchRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                (c.AdmissionBatchName.ToLower() == admissionBatch.AdmissionBatchName.ToLower())
                && c.AdmissionBatchId != admissionBatch.AdmissionBatchId);

        if (duplicateAdmissionBatch != null)
        {
            return Conflict($"A admission batch with the name already exists (ID: {duplicateAdmissionBatch.AdmissionBatchName}).");
        }

        existingRec.AdmissionBatchName = admissionBatch.AdmissionBatchName;
        existingRec.IsActive = admissionBatch.IsActive;
        existingRec.ModifiedBy  = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = admissionBatch.IPAddress;

        _admBatchRepo.Update(existingRec); // Use the updated object
        await _admBatchRepo.SaveAsync();
        return NoContent();
    }

    [HttpGet("country")]
    public async Task<ActionResult<IEnumerable<CountryMasterModel>>> GetCountries([FromQuery] bool forceRefresh = false) =>
        Ok(await _countryRepo.GetAllAsync(forceRefresh));


    [HttpGet("country/{id}")]
    public async Task<ActionResult<IEnumerable<CountryMasterModel>>> GetCountryById(int id) =>
       Ok(await _countryRepo.GetByIdAsync(id));

    [HttpPost("country")]
    public async Task<ActionResult> AddCountry(CountryMasterModel country)
    {
        // Check for unique constraint violation
        var duplicateCountry = (await _countryRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                c.CountryName.ToLower() == country.CountryName.ToLower());

        if (duplicateCountry != null)
        {
            return Conflict($"A country with the name already exists (ID: {duplicateCountry.CountryName}).");
        }

        var countryMst = new CountryMaster
        {
            CountryId = country.CountryId,
            CountryName = country.CountryName,
            IsActive = country.IsActive,
            CreatedBy  = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = country.IPAddress,
            MACAddress = country.MACAddress,
            OrganizationId = ORGANIZATIONID
        };
        await _countryRepo.AddAsync(countryMst);
        await _countryRepo.SaveAsync();
        return CreatedAtAction(nameof(GetCountries), new { id = country.CountryId }, country);
    }

    [HttpPut("country/{id}")]
    public async Task<ActionResult> UpdateCountry([FromRoute] int id, [FromBody] CountryMasterModel country)
    {
        var existingRec = await _countryRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"Country with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicateCountry = (await _countryRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                (c.CountryName.ToLower() == country.CountryName.ToLower())
                && c.CountryId != country.CountryId);

        if (duplicateCountry != null)
        {
            return Conflict($"A country with the name already exists (ID: {duplicateCountry.CountryName}).");
        }

        existingRec.CountryName = country.CountryName;
        existingRec.IsActive = country.IsActive;
        existingRec.ModifiedBy  = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = "";
        existingRec.MACAddress = "";

        _countryRepo.Update(existingRec); // Use the updated object
        await _countryRepo.SaveAsync();
        return NoContent();
    }

    [HttpGet("state")]
    public async Task<ActionResult<IEnumerable<StateMasterModel>>> GetStates([FromQuery] bool forceRefresh = false)
    {
        var states = await _stateRepo.GetAllAsync(forceRefresh);

        var result = states
            .Cast<StateMaster>() // since repo returns IEnumerable<T>
            .Select(s => new StateMasterModel
            {
                StateId = s.StateId,
                StateName = s.StateName,
                CountryId = s.CountryId,
                CountryName = s.Country.CountryName,
                IsActive = s.IsActive
            })
            .ToList();

        return Ok(result);
    }

    [HttpGet("state/{id}")]
    public async Task<ActionResult<IEnumerable<StateMasterModel>>> GetStateById(int id) =>
       Ok(await _stateRepo.GetByIdAsync(id));

    [HttpPost("state")]
    public async Task<ActionResult> AddState(StateMasterModel state)
    {
        // Check for unique constraint violation
        var duplicateState = (await _stateRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                c.StateName.ToLower() == state.StateName.ToLower());

        if (duplicateState != null)
        {
            return Conflict($"A state with the name already exists (ID: {duplicateState.StateName}).");
        }

        var stateMst = new StateMaster
        {
            StateId = state.StateId,
            StateName = state.StateName,
            CountryId = state.CountryId,
            IsActive = state.IsActive,
            CreatedBy  = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = state.IPAddress,
            MACAddress = state.MACAddress,
            OrganizationId = ORGANIZATIONID
        };
        await _stateRepo.AddAsync(stateMst);
        await _stateRepo.SaveAsync();
        return CreatedAtAction(nameof(GetStates), new { id = state.StateId }, state);
    }

    [HttpPut("state/{id}")]
    public async Task<ActionResult> UpdateState([FromRoute] int id, [FromBody] StateMasterModel state)
    {
        var existingRec = await _stateRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"State with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicateState = (await _stateRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                (c.StateName.ToLower() == state.StateName.ToLower())
                && c.StateId != state.StateId);

        if (duplicateState != null)
        {
            return Conflict($"A state with the name already exists (ID: {duplicateState.StateName}).");
        }

        existingRec.StateName = state.StateName;
        existingRec.CountryId = state.CountryId;
        existingRec.IsActive = state.IsActive;
        existingRec.ModifiedBy  = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = string.Empty;
        existingRec.MACAddress = string.Empty;

        _stateRepo.Update(existingRec); // Use the updated object
        await _stateRepo.SaveAsync();
        return NoContent();
    }

    [HttpGet("district")]
    public async Task<ActionResult<IEnumerable<DistrictMasterModel>>> GetDistricts([FromQuery] bool forceRefresh = false)
    {
        var districts = await _districtRepo.GetAllAsync(forceRefresh);

        var result = districts
            .Cast<DistrictMaster>() // since repo returns IEnumerable<T>
            .Select(s => new DistrictMasterModel
            {
                DistrictId = s.DistrictId,
                DistrictName = s.DistrictName,
                StateId = s.StateId,
                StateName = s.State.StateName,
                IsActive = s.IsActive
            })
            .ToList();

        return Ok(result);
    }

    [HttpGet("district/{id}")]
    public async Task<ActionResult<IEnumerable<DistrictMasterModel>>> GetDistrictById(int id) =>
       Ok(await _districtRepo.GetByIdAsync(id));

    [HttpPost("district")]
    public async Task<ActionResult> AddDistrict(DistrictMasterModel district)
    {
        // Check for unique constraint violation
        var duplicateDistrict = (await _districtRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                c.DistrictName.ToLower() == district.DistrictName.ToLower());

        if (duplicateDistrict != null)
        {
            return Conflict($"A district with the name already exists (ID: {duplicateDistrict.DistrictName}).");
        }

        var districtMst = new DistrictMaster
        {
            DistrictId = district.DistrictId,
            DistrictName = district.DistrictName,
            StateId = district.StateId,
            IsActive = district.IsActive,
            CreatedBy = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = district.IPAddress,
            MACAddress = district.MACAddress,
            OrganizationId = ORGANIZATIONID
        };
        await _districtRepo.AddAsync(districtMst);
        await _districtRepo.SaveAsync();
        return CreatedAtAction(nameof(GetStates), new { id = district.DistrictId }, district);
    }

    [HttpPut("district/{id}")]
    public async Task<ActionResult> UpdateDistrict([FromRoute] int id, [FromBody] DistrictMasterModel district)
    {
        var existingRec = await _districtRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"District with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicatedistrict = (await _districtRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                (c.DistrictName.ToLower() == district.DistrictName.ToLower())
                && c.DistrictId != district.DistrictId);

        if (duplicatedistrict != null)
        {
            return Conflict($"A district with the name already exists (ID: {duplicatedistrict.DistrictName}).");
        }

        existingRec.DistrictName = district.DistrictName;
        existingRec.StateId = district.StateId;
        existingRec.IsActive = district.IsActive;
        existingRec.ModifiedBy = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = string.Empty;
        existingRec.MACAddress = string.Empty;

        _districtRepo.Update(existingRec); // Use the updated object
        await _districtRepo.SaveAsync();
        return NoContent();
    }

    //=========================================================
    [HttpGet("city")]
    public async Task<ActionResult<IEnumerable<CityMasterModel>>> GetCities([FromQuery] bool forceRefresh = false)
    {
        var cities = await _cityRepo.GetAllAsync(forceRefresh);

        var result = cities
            .Cast<CityMaster>() // since repo returns IEnumerable<T>
            .Select(s => new CityMasterModel
            {
                CityId = s.CityId,
                DistrictId = s.DistrictId,
                CityName = s.CityName,
                DistrictName = s.District.DistrictName,
                // StateId = s.StateId,
                //StateName = s.State.StateName,
                IsActive = s.IsActive
            })
            .ToList();

        return Ok(result);
    }

    [HttpGet("city/{id}")]
    public async Task<ActionResult<IEnumerable<CityMasterModel>>> GetCityById(int id) =>
       Ok(await _cityRepo.GetByIdAsync(id));

    [HttpPost("city")]
    public async Task<ActionResult> AddCity(CityMasterModel city)
    {
        // Check for unique constraint violation
        var duplicateCity = (await _cityRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                c.CityName.ToLower() == city.CityName.ToLower());

        if (duplicateCity != null)
        {
            return Conflict($"A city with the name already exists (ID: {duplicateCity.CityName}).");
        }

        var cityMst = new CityMaster
        {
            CityId = city.CityId,
            CityName = city.CityName,
            DistrictId = city.DistrictId,
            IsActive = city.IsActive,
            CreatedBy = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = city.IPAddress,
            MACAddress = city.MACAddress,
            OrganizationId = ORGANIZATIONID
        };
        await _cityRepo.AddAsync(cityMst);
        await _cityRepo.SaveAsync();
        return CreatedAtAction(nameof(GetCities), new { id = city .CityId}, city);
    }

    [HttpPut("city/{id}")]
    public async Task<ActionResult> UpdateCity([FromRoute] int id, [FromBody] CityMasterModel city)
    {
        var existingRec = await _cityRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"City with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicatecity = (await _cityRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                (c.CityName.ToLower() == city.CityName.ToLower())
                && c.DistrictId != city.DistrictId);

        if (duplicatecity != null)
        {
            return Conflict($"A citywith the name already exists (ID: {duplicatecity.CityName}).");
        }

        existingRec.CityName = city.CityName;
        existingRec.DistrictId = city.DistrictId;
        existingRec.IsActive = city.IsActive;
        existingRec.ModifiedBy = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = string.Empty;
        existingRec.MACAddress = string.Empty;

        _cityRepo.Update(existingRec); // Use the updated object
        await _cityRepo.SaveAsync();
        return NoContent();
    }

    // =======================================
    [HttpGet("receiptType")]
    public async Task<ActionResult<IEnumerable<ReceiptTypeMasterModel>>> GetReceiptTypes([FromQuery] bool forceRefresh = false)
    {
        var data = await _receiptTypeRepo.GetAllAsync(forceRefresh);

        var result = data
            .Cast<ReceiptTypeMaster>() // since repo returns IEnumerable<T>
            .Select(s => new ReceiptTypeMasterModel
            {
                ReceiptTypeId = s.ReceiptTypeId,
                ReceiptTypeName = s.ReceiptTypeName,
                ReceiptCodeId = s.ReceiptCodeId,
                ReceiptCodeName = s.ReceiptCodeMaster != null ? s.ReceiptCodeMaster.ReceiptCodeName : string.Empty,
                ReceiptBelongsTo = s.ReceiptBelongsTo,
                ReceiptBelongsToName = s.ReceiptBelongsToMaster != null ? s.ReceiptBelongsToMaster.ReceiptBelongsToName : string.Empty,
                AccountNo = s.AccountNo,
                LinkWithAccounts = s.LinkWithAccounts,
                IsAdmissionType = s.IsAdmissionType,
                IsLateFineApplicable = s.IsLateFineApplicable,
                ShowInStudentLogin = s.ShowInStudentLogin,
                IsOnlineVisibility = s.IsOnlineVisibility,
                IsActive = s.IsActive
            })
            .ToList();

        return Ok(result);
    }

    [HttpGet("receiptType/{id:int}")]
    public async Task<ActionResult<IEnumerable<ReceiptTypeMasterModel>>> ReceiptTypeById(int id) =>
       Ok(await _receiptTypeRepo.GetByIdAsync(id));

    [HttpPost("receiptType")]
    public async Task<ActionResult> AddReceiptType(ReceiptTypeMasterModel receiptTypeModel)
    {
        // Check for unique constraint violation
        var duplicate = (await _receiptTypeRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                c.ReceiptTypeName.ToLower() == receiptTypeModel.ReceiptTypeName.ToLower());

        if (duplicate != null)
        {
            return Conflict($"A Receipt Type with the name already exists (ID: {duplicate.ReceiptTypeName}).");
        }

        var mst = new ReceiptTypeMaster
        {
            ReceiptTypeName = receiptTypeModel.ReceiptTypeName,
            ReceiptCodeId = receiptTypeModel.ReceiptCodeId,
            ReceiptBelongsTo = receiptTypeModel.ReceiptBelongsTo,
            AccountNo = receiptTypeModel.AccountNo,
            LinkWithAccounts = receiptTypeModel.LinkWithAccounts,
            IsAdmissionType = receiptTypeModel.IsAdmissionType,
            IsLateFineApplicable = receiptTypeModel.IsLateFineApplicable,
            ShowInStudentLogin = receiptTypeModel.ShowInStudentLogin,
            IsOnlineVisibility = receiptTypeModel.IsOnlineVisibility,
            IsActive = receiptTypeModel.IsActive,
            CreatedBy = USERID,
            CreatedDate = DateTime.Now,
            ModifiedDate = null,
            IPAddress = IPADDRESS,
            MACAddress = MACADDRESS,
            OrganizationId = ORGANIZATIONID
        };
        await _receiptTypeRepo.AddAsync(mst);
        await _receiptTypeRepo.SaveAsync();

        return CreatedAtAction(nameof(GetReceiptTypes), new { id = mst.ReceiptTypeId }, mst);
    }

    [HttpPut("receiptType/{id}")]
    public async Task<ActionResult> UpdateReceiptType([FromRoute] int id, [FromBody] ReceiptTypeMasterModel receiptTypeModel)
    {
        var existingRec = await _receiptTypeRepo.GetByIdAsync(id); // Await the task to get the actual object
        if (existingRec == null)
        {
            return NotFound($"Receipt Type with id {id} not found.");
        }

        // Check for unique constraint violation
        var duplicate = (await _receiptTypeRepo.GetAllAsync(true))
        .FirstOrDefault(c =>
                (c.ReceiptTypeName.ToLower() == receiptTypeModel.ReceiptTypeName.ToLower())
                && c.ReceiptTypeId != id);

        if (duplicate != null)
        {
            return Conflict($"A Receipt Type with the Receipt Type Name already exists (ID: {duplicate.ReceiptTypeName}).");
        }

        existingRec.ReceiptTypeName = receiptTypeModel.ReceiptTypeName;
        existingRec.ReceiptCodeId = receiptTypeModel.ReceiptCodeId;
        existingRec.ReceiptBelongsTo = receiptTypeModel.ReceiptBelongsTo;
        existingRec.AccountNo = receiptTypeModel.AccountNo;
        existingRec.LinkWithAccounts = receiptTypeModel.LinkWithAccounts;
        existingRec.IsAdmissionType = receiptTypeModel.IsAdmissionType;
        existingRec.IsLateFineApplicable = receiptTypeModel.IsLateFineApplicable;
        existingRec.ShowInStudentLogin = receiptTypeModel.ShowInStudentLogin;
        existingRec.IsOnlineVisibility = receiptTypeModel.IsOnlineVisibility;
        existingRec.IsActive = receiptTypeModel.IsActive;
        existingRec.ModifiedBy = USERID;
        existingRec.ModifiedDate = DateTime.Now;
        existingRec.IPAddress = IPADDRESS;
        existingRec.MACAddress = MACADDRESS;

        _receiptTypeRepo.Update(existingRec); // Use the updated object
        await _receiptTypeRepo.SaveAsync();

        return NoContent();
    }

}
