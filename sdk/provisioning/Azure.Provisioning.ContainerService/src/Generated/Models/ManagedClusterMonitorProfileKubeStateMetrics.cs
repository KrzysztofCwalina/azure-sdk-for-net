// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable enable

using Azure.Provisioning.Primitives;
using System;

namespace Azure.Provisioning.ContainerService;

/// <summary>
/// Kube State Metrics profile for the Azure Managed Prometheus addon. These
/// optional settings are for the kube-state-metrics pod that is deployed with
/// the addon. See aka.ms/AzureManagedPrometheus-optional-parameters for
/// details.
/// </summary>
public partial class ManagedClusterMonitorProfileKubeStateMetrics : ProvisionableConstruct
{
    /// <summary>
    /// Comma-separated list of additional Kubernetes label keys that will be
    /// used in the resource&apos;s labels metric (Example:
    /// &apos;namespaces=[k8s-label-1,k8s-label-n,...],pods=[app],...&apos;).
    /// By default the metric contains only resource name and namespace labels.
    /// </summary>
    public BicepValue<string> MetricLabelsAllowlist 
    {
        get { Initialize(); return _metricLabelsAllowlist!; }
        set { Initialize(); _metricLabelsAllowlist!.Assign(value); }
    }
    private BicepValue<string>? _metricLabelsAllowlist;

    /// <summary>
    /// Comma-separated list of Kubernetes annotation keys that will be used in
    /// the resource&apos;s labels metric (Example:
    /// &apos;namespaces=[kubernetes.io/team,...],pods=[kubernetes.io/team],...&apos;).
    /// By default the metric contains only resource name and namespace labels.
    /// </summary>
    public BicepValue<string> MetricAnnotationsAllowList 
    {
        get { Initialize(); return _metricAnnotationsAllowList!; }
        set { Initialize(); _metricAnnotationsAllowList!.Assign(value); }
    }
    private BicepValue<string>? _metricAnnotationsAllowList;

    /// <summary>
    /// Creates a new ManagedClusterMonitorProfileKubeStateMetrics.
    /// </summary>
    public ManagedClusterMonitorProfileKubeStateMetrics()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// ManagedClusterMonitorProfileKubeStateMetrics.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _metricLabelsAllowlist = DefineProperty<string>("MetricLabelsAllowlist", ["metricLabelsAllowlist"]);
        _metricAnnotationsAllowList = DefineProperty<string>("MetricAnnotationsAllowList", ["metricAnnotationsAllowList"]);
    }
}
