import { useState } from 'react';
import { api } from '../services/api';

export default function Register({ onRegistered, onGoToLogin }) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [fullName, setFullName] = useState('');
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setSuccess('');
    setLoading(true);
    try {
      const data = await api.register(username, password, fullName);
      setSuccess(data.message);
      setTimeout(() => onRegistered(), 1500);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="auth-container">
      <div className="card auth-card shadow">
        <div className="card-body p-4">
          <div className="text-center mb-4">
            <div className="auth-icon mb-3">
              <i className="bi bi-person-plus-fill"></i>
            </div>
            <h2 className="card-title fw-bold">Crear Cuenta</h2>
            <p className="text-muted">Regístrate para usar CenevalApp</p>
          </div>

          {error && (
            <div className="alert alert-danger d-flex align-items-center py-2" role="alert">
              <i className="bi bi-exclamation-triangle-fill me-2"></i>
              <span>{error}</span>
            </div>
          )}
          {success && (
            <div className="alert alert-success d-flex align-items-center py-2" role="alert">
              <i className="bi bi-check-circle-fill me-2"></i>
              <span>{success}</span>
            </div>
          )}

          <form onSubmit={handleSubmit}>
            <div className="mb-3">
              <label htmlFor="reg-fullname" className="form-label fw-semibold">
                <i className="bi bi-person-badge me-1"></i>Nombre Completo
              </label>
              <input
                id="reg-fullname"
                type="text"
                className="form-control"
                placeholder="Ej: Juan Pérez"
                value={fullName}
                onChange={(e) => setFullName(e.target.value)}
                required
                autoFocus
              />
            </div>
            <div className="mb-3">
              <label htmlFor="reg-username" className="form-label fw-semibold">
                <i className="bi bi-person me-1"></i>Usuario
              </label>
              <input
                id="reg-username"
                type="text"
                className="form-control"
                placeholder="Elige un nombre de usuario"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
              />
            </div>
            <div className="mb-4">
              <label htmlFor="reg-password" className="form-label fw-semibold">
                <i className="bi bi-lock me-1"></i>Contraseña
              </label>
              <input
                id="reg-password"
                type="password"
                className="form-control"
                placeholder="Crea una contraseña"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
            </div>
            <button
              type="submit"
              className="btn btn-success w-100 fw-semibold py-2"
              disabled={loading}
            >
              {loading ? (
                <>
                  <span className="spinner-border spinner-border-sm me-2"></span>
                  Registrando...
                </>
              ) : (
                <>
                  <i className="bi bi-person-check me-2"></i>
                  Registrarse
                </>
              )}
            </button>
          </form>

          <hr className="my-4" />
          <p className="text-center mb-0">
            ¿Ya tienes cuenta?{' '}
            <button className="btn btn-link p-0 fw-semibold" onClick={onGoToLogin}>
              Inicia sesión
            </button>
          </p>
        </div>
      </div>
    </div>
  );
}
