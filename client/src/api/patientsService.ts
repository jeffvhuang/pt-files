import { AxiosResponse } from 'axios';
import * as G from './generated';
import { message } from 'antd';
import { keys } from '../helpers/keys';
import { ApiService } from './apiService';

const { apiUrl } = keys;

class PatientsService extends ApiService {
  createPatient = async (patient: G.ICreatePatientCommand): Promise<G.IGetPatientVm> => {
    try {
      const url = `${apiUrl}/patients`;
      const resp = (await this.post(url, patient)) as AxiosResponse<number>;
      return { ...patient, id: resp.data };
    } catch (e) {
      return this.handleRequestError(e);
    }
  };

  getPatients = async (): Promise<G.IGetPatientVm[]> => {
    try {
      const url = `${apiUrl}/patients`;
      const resp = (await this.get(url)) as AxiosResponse<G.IGetPatientVm[]>;
      return resp.data;
    } catch (e) {
      return this.handleRequestError(e);
    }
  };

  getPatient = async (id: string): Promise<G.IGetPatientVm> => {
    try {
      const url = `${apiUrl}/patients/${id}`;
      const resp = (await this.get(url)) as AxiosResponse<G.IGetPatientVm>;
      return resp.data;
    } catch (e) {
      return this.handleRequestError(e);
    }
  };

  updatePatient = async (id: string, patient: G.IUpdatePatientCommand): Promise<void> => {
    try {
      const url = `${apiUrl}/patients/${id}`;
      await this.put(url, patient);
      message.success('Patient updated');
    } catch (e) {
      return this.handleRequestError(e);
    }
  };

  deletePatient = async (id: string): Promise<void> => {
    try {
      const url = `${apiUrl}/patients/${id}`;
      await this.delete(url);
      message.success('Patient deleted');
    } catch (e) {
      return this.handleRequestError(e);
    }
  };
}

export const patientsService = new PatientsService();
