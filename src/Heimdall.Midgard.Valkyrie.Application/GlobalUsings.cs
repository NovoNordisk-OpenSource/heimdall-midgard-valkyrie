// Global using directives

global using AutoMapper;
global using BeHeroes.CodeOps.Abstractions.Aggregates;
global using BeHeroes.CodeOps.Abstractions.Commands;
global using BeHeroes.CodeOps.Abstractions.Events;
global using BeHeroes.CodeOps.Abstractions.Facade;
global using Heimdall.Midgard.Valkyrie.Domain.Aggregates;
global using Heimdall.Midgard.Valkyrie.Domain.Events;
global using Heimdall.Midgard.Valkyrie.Domain.Services;
global using Heimdall.Midgard.Valkyrie.Domain.ValueObjects;
global using Heimdall.Midgard.Valkyrie.Application.Commands;
global using Heimdall.Midgard.Valkyrie.Application.Events.Integration;
global using Heimdall.Midgard.Valkyrie.Application.Mapping.Converters.Events;
global using Heimdall.Midgard.Valkyrie.Application.Mapping.Converters.Commands;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using System.Diagnostics;
global using System.Diagnostics.Metrics;
global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;