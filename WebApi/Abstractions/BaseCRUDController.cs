using AutoMapper;
using Domain.Entities.CoreService;
using FluentValidation;
using Infrastructure.Masstransit;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Masstransit;
using Services.Contracts.Masstransit;
using Services.Repositories.Abstractions.CoreService;
using Swashbuckle.AspNetCore.Annotations;

namespace CoreService.WebApi.Abstractions;

/// <summary>
/// Базовый абстрактный класс для реализации контроллера со стандартным набором CRUD-операций
/// </summary>
/// <typeparam name="TEntity">БД сущность</typeparam>
/// <typeparam name="TEntityDTO">ДТО сущность</typeparam>
[Route("api/[controller]")]
[ApiController]
public abstract class BaseCRUDController<TEntity, TEntityDTO> : ControllerBase
    where TEntity : class, IEntityId
    where TEntityDTO : class, IEntityId
{
    #region Public and private fields, properties, constructor

    protected readonly IEFGenericRepository<TEntity> _baseRepo;
    protected readonly IMapper _mapper;
    protected readonly IValidator<TEntityDTO> _createValidator;
    protected readonly IValidator<TEntityDTO> _updateValidator;
    protected readonly IMassTransitHelper _massTransit;

    protected BaseCRUDController(IEFGenericRepository<TEntity> baseRepo, IMapper mapper,
                                 IValidator<TEntityDTO> createValidator, IValidator<TEntityDTO> updateValidator,
                                 IMassTransitHelper massTransit)
    {
        _massTransit = massTransit ?? throw new ArgumentNullException(nameof(massTransit));
        _baseRepo = baseRepo ?? throw new ArgumentNullException(nameof(baseRepo));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _createValidator = createValidator ?? throw new ArgumentNullException(nameof(createValidator));
        _updateValidator = updateValidator ?? throw new ArgumentNullException(nameof(updateValidator));
    }

    #endregion

    #region Public and private methods
    [HttpGet]
    [SwaggerOperation(Summary = "Получение списка объектов")]
    public virtual async Task<ActionResult<IEnumerable<TEntityDTO>>> Get()
    {
        var message = new MessageDto() { MessageText="First"};
        await _massTransit.SendMessageAsync(message, MassTransitConstants.MassTransitFirstQueueName);
        await Task.Delay(300);
        var messageSecond = new MessageDto() { MessageText = "Second" };
        await _massTransit.SendMessageAsync(messageSecond, MassTransitConstants.MassTransitSecondQueueName);
        await Task.Delay(300);
        //await _massTransit.ReceiveMessageAsync(MassTransitConstants.MassTransitQueueName);
        return Ok();
        //IEnumerable<TEntity> entities = await _baseRepo.GetAllAsync();
        //return Ok(_mapper.Map<IEnumerable<TEntityDTO>>(entities));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Получение объекта")]
    public virtual async Task<ActionResult<TEntityDTO>> Get([SwaggerParameter("Идентификатор")] int id)
    {
        TEntity entity = await _baseRepo.FindByIdAsync(id);
        if (entity == null)
            return NotFound();
        TEntityDTO map = _mapper.Map<TEntityDTO>(entity);
        return Ok(map);
    }

    [HttpPost]
    [SwaggerOperation("Создание объекта")]
    public virtual async Task<ActionResult> Post([FromBody, SwaggerParameter("Новый объект")] TEntityDTO entityDTO)
    {
        var validationResult = _createValidator.Validate(entityDTO);
        if (!validationResult.IsValid)
            return BadRequest(validationResult);

        await _baseRepo.CreateAsync(_mapper.Map<TEntity>(entityDTO));
        return NoContent();
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Редактирование объекта")]
    public virtual async Task<ActionResult> Put([SwaggerParameter("Идентификатор")] int id, [FromBody, SwaggerParameter("Редактируемый объект")] TEntityDTO entityDTO)
    {
        if (id != entityDTO.Id)
            return BadRequest();

        var validationResult = _updateValidator.Validate(entityDTO);
        if (!validationResult.IsValid)
            return BadRequest(validationResult);
        await _baseRepo.UpdateAsync(_mapper.Map<TEntity>(entityDTO));
        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Удаление объекта")]
    public virtual async Task<ActionResult> Delete([SwaggerParameter("Идентификатор")] int id)
    {
        var entity = await _baseRepo.FindByIdAsync(id);
        if (entity == null)
            return NotFound();
        await _baseRepo.RemoveAsync(entity);
        return NoContent();
    }
    #endregion
}
