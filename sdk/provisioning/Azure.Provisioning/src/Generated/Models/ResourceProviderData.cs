// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable enable

using Azure.Core;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using System;

namespace Azure.Provisioning.Resources;

/// <summary>
/// ResourceProviderData.
/// </summary>
public partial class ResourceProviderData : ProvisionableConstruct
{
    /// <summary>
    /// Gets the Id.
    /// </summary>
    public BicepValue<ResourceIdentifier> Id 
    {
        get { Initialize(); return _id!; }
    }
    private BicepValue<ResourceIdentifier>? _id;

    /// <summary>
    /// Gets the Namespace.
    /// </summary>
    public BicepValue<string> Namespace 
    {
        get { Initialize(); return _namespace!; }
    }
    private BicepValue<string>? _namespace;

    /// <summary>
    /// Gets the RegistrationState.
    /// </summary>
    public BicepValue<string> RegistrationState 
    {
        get { Initialize(); return _registrationState!; }
    }
    private BicepValue<string>? _registrationState;

    /// <summary>
    /// Gets the RegistrationPolicy.
    /// </summary>
    public BicepValue<string> RegistrationPolicy 
    {
        get { Initialize(); return _registrationPolicy!; }
    }
    private BicepValue<string>? _registrationPolicy;

    /// <summary>
    /// Gets the ResourceTypes.
    /// </summary>
    public BicepList<ProviderResourceType> ResourceTypes 
    {
        get { Initialize(); return _resourceTypes!; }
    }
    private BicepList<ProviderResourceType>? _resourceTypes;

    /// <summary>
    /// Gets the ProviderAuthorizationConsentState.
    /// </summary>
    public BicepValue<ProviderAuthorizationConsentState> ProviderAuthorizationConsentState 
    {
        get { Initialize(); return _providerAuthorizationConsentState!; }
    }
    private BicepValue<ProviderAuthorizationConsentState>? _providerAuthorizationConsentState;

    /// <summary>
    /// Creates a new ResourceProviderData.
    /// </summary>
    public ResourceProviderData()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of ResourceProviderData.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
        _namespace = DefineProperty<string>("Namespace", ["namespace"], isOutput: true);
        _registrationState = DefineProperty<string>("RegistrationState", ["registrationState"], isOutput: true);
        _registrationPolicy = DefineProperty<string>("RegistrationPolicy", ["registrationPolicy"], isOutput: true);
        _resourceTypes = DefineListProperty<ProviderResourceType>("ResourceTypes", ["resourceTypes"], isOutput: true);
        _providerAuthorizationConsentState = DefineProperty<ProviderAuthorizationConsentState>("ProviderAuthorizationConsentState", ["providerAuthorizationConsentState"], isOutput: true);
    }
}
