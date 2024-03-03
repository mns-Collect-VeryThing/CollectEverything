import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'CollectEverything',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:7600/',
    redirectUri: baseUrl,
    clientId: 'CollectEverything_App',
    responseType: 'code',
    scope: 'IdentityService AdministrationService SaasService',
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'https://localhost:7500',
      rootNamespace: 'CollectEverything',
    },
  },
} as Environment;
