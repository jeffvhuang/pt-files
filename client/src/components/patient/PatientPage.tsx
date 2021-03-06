import React from 'react';
import { connect, ConnectedProps } from 'react-redux';
import { RouteComponentProps, withRouter } from 'react-router-dom';
import { compose } from 'redux';
import * as patientActions from '../../stores/patients/patientActions';
import { ApplicationState } from '../../stores';
import PatientForm from './PatientForm';
import moment from 'moment';
import { PatientBaseForm } from '../../helpers/formHelper';
import style from './patient.scss';
import { Button, Modal } from 'antd';
import { DeleteOutlined, ExclamationCircleOutlined } from '@ant-design/icons';

const mapStateToProps = (state: ApplicationState) => state.patient;
const connector = connect(mapStateToProps, patientActions);

type Props = ConnectedProps<typeof connector> & RouteComponentProps<{ patientId: string }>;
type State = { isNew: boolean };

class PatientPage extends React.Component<Props, State> {
  state = {
    isNew: this.props.match.params.patientId === 'new'
  };

  componentDidMount() {
    !this.state.isNew && this.ensureDataFetched();
  }

  ensureDataFetched = () => {
    const { match, getPatient, id, list, selectPatient } = this.props;
    const { patientId } = match.params;
    const pId = parseInt(patientId);

    if (id !== pId) {
      const patient = list.find((c) => c.id === pId);

      if (patient) return selectPatient(patient);

      getPatient(pId);
    }
  };

  save = (values: PatientBaseForm) => {
    const { id, createPatient, updatePatient } = this.props;
    const dob = values.dob?.format('YYYY-MM-DD') ?? '';

    if (this.state.isNew) return createPatient({ ...values, dob });
    updatePatient(id, { ...values, id, dob });
  };

  getPatientData = () => {
    const { honorific, firstName, lastName, dob, email, homePhone, mobilePhone } = this.props;
    const { countryCode, gender, occupation } = this.props;

    return {
      honorific,
      firstName,
      lastName,
      dob: dob ? moment(dob) : undefined,
      email,
      countryCode,
      homePhone,
      mobilePhone,
      gender,
      occupation
    };
  };

  showDelete = () => {
    const { deletePatient, id } = this.props;
    Modal.confirm({
      title: 'Are you sure?',
      icon: <ExclamationCircleOutlined />,
      content: 'Deleting patient will remove all related casefiles and consultations!',
      okText: 'Delete',
      okType: 'danger',
      onOk: () => deletePatient(id)
    });
  };

  render() {
    const { isFetching, error } = this.props;
    const { isNew } = this.state;
    const data = isNew ? undefined : this.getPatientData();

    return (
      <>
        <div className={style.header}>
          <h3>{isNew ? 'New Patient' : 'Patient Details'}</h3>
        </div>
        {!isNew && (
          <div className={style.deleteRow}>
            <Button danger icon={<DeleteOutlined />} onClick={this.showDelete} />
          </div>
        )}
        <PatientForm
          data={data}
          onSubmit={this.save}
          isSaving={isFetching}
          isNew={isNew}
          error={error}
        />
      </>
    );
  }
}

export default compose<React.ComponentType>(withRouter, connector)(PatientPage);
