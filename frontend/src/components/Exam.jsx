import { useState, useEffect } from 'react';
import { api } from '../services/api';

// ── Configuración de niveles ─────────────────────────────────────────────────
const DIFFICULTY_CONFIG = {
  3: { label: 'Fácil', color: '#22c55e', bg: '#dcfce7', border: '#86efac' },
  1: { label: 'Normal', color: '#f59e0b', bg: '#fef9c3', border: '#fde047' },
  2: { label: 'Difícil', color: '#ef4444', bg: '#fee2e2', border: '#fca5a5' },
};
const NEXT_MAP = { 3: 1, 1: 2 };

// ── Badge de dificultad ──────────────────────────────────────────────────────
function DifficultyBadge({ difficulty, consecutiveHits }) {
  const cfg = DIFFICULTY_CONFIG[difficulty] ?? DIFFICULTY_CONFIG[3];
  return (
    <div style={{
      display: 'inline-flex', alignItems: 'center', gap: '8px',
      background: cfg.bg, border: `1.5px solid ${cfg.border}`,
      borderRadius: '999px', padding: '4px 14px',
      fontWeight: 700, fontSize: '0.85rem', color: cfg.color,
      boxShadow: '0 1px 4px rgba(0,0,0,0.07)',
      transition: 'all 0.3s ease',
    }}>
      <span>{cfg.icon}</span>
      <span>{cfg.label}</span>
      {consecutiveHits > 0 && (
        <span style={{
          background: cfg.color, color: '#fff',
          borderRadius: '999px', padding: '0 7px', fontSize: '0.75rem',
        }}>
          {consecutiveHits}/5
        </span>
      )}
    </div>
  );
}

// ── Modal de subida de nivel ─────────────────────────────────────────────────
function LevelUpModal({ currentDifficulty, onAccept, onReject, loading }) {
  const current = DIFFICULTY_CONFIG[currentDifficulty] ?? DIFFICULTY_CONFIG[3];
  const nextDiff = NEXT_MAP[currentDifficulty];
  const next = DIFFICULTY_CONFIG[nextDiff] ?? current;

  return (
    <div style={{
      position: 'fixed', inset: 0, zIndex: 1000,
      background: 'rgba(0,0,0,0.55)', backdropFilter: 'blur(4px)',
      display: 'flex', alignItems: 'center', justifyContent: 'center',
    }}>
      <div style={{
        background: '#fff', borderRadius: '20px', padding: '40px 36px',
        maxWidth: '420px', width: '90%', textAlign: 'center',
        boxShadow: '0 20px 60px rgba(0,0,0,0.25)',
        animation: 'popIn 0.25s cubic-bezier(.175,.885,.32,1.275)',
      }}>
        <div style={{
          fontSize: '3.5rem', marginBottom: '12px',
          animation: 'bounceAnim 0.8s ease infinite alternate'
        }}>🏆</div>
        <h2 style={{ margin: '0 0 8px', color: '#1e293b', fontWeight: 800, fontSize: '1.4rem' }}>
          ¡Subida de Nivel!
        </h2>
        <p style={{ color: '#64748b', marginBottom: '24px', lineHeight: 1.5 }}>
          Respondiste <strong>5 preguntas seguidas correctamente</strong>.<br />
          ¿Quieres avanzar de{' '}
          <strong style={{ color: current.color }}>{current.label}</strong>
          {' '}a{' '}
          <strong style={{ color: next.color }}>{next.label}</strong>?
        </p>

        <div style={{
          display: 'flex', alignItems: 'center', justifyContent: 'center',
          gap: '12px', marginBottom: '28px',
        }}>
          <DifficultyBadge difficulty={currentDifficulty} consecutiveHits={0} />
          <span style={{ color: '#94a3b8', fontSize: '1.2rem' }}>→</span>
          <DifficultyBadge difficulty={nextDiff} consecutiveHits={0} />
        </div>

        <div style={{ display: 'flex', gap: '12px', justifyContent: 'center' }}>
          <button
            id="btn-levelup-accept"
            onClick={onAccept}
            disabled={loading}
            style={{
              background: 'linear-gradient(135deg, #22c55e, #16a34a)',
              color: '#fff', border: 'none', borderRadius: '12px',
              padding: '12px 28px', fontWeight: 700, fontSize: '1rem',
              cursor: loading ? 'not-allowed' : 'pointer',
              boxShadow: '0 4px 12px rgba(34,197,94,0.35)', flex: 1,
            }}
          >
            {loading ? '...' : '✅ Aceptar'}
          </button>
          <button
            id="btn-levelup-reject"
            onClick={onReject}
            disabled={loading}
            style={{
              background: '#f1f5f9', color: '#475569',
              border: '1.5px solid #cbd5e1', borderRadius: '12px',
              padding: '12px 28px', fontWeight: 700, fontSize: '1rem',
              cursor: loading ? 'not-allowed' : 'pointer', flex: 1,
            }}
          >
            ❌ Rechazar
          </button>
        </div>
        <p style={{ color: '#94a3b8', fontSize: '0.78rem', marginTop: '16px', marginBottom: 0 }}>
          Si rechazas, continuarás con preguntas del mismo nivel.
        </p>
      </div>

      <style>{`
        @keyframes popIn {
          from { transform: scale(0.75); opacity: 0; }
          to   { transform: scale(1);    opacity: 1; }
        }
        @keyframes bounceAnim {
          from { transform: translateY(0);   }
          to   { transform: translateY(-8px);}
        }
      `}</style>
    </div>
  );
}

// ── Modal de confirmación de reinicio ────────────────────────────────────────
function RestartConfirmModal({ onConfirm, onCancel }) {
  return (
    <div style={{
      position: 'fixed', inset: 0, zIndex: 1000,
      background: 'rgba(0,0,0,0.55)', backdropFilter: 'blur(4px)',
      display: 'flex', alignItems: 'center', justifyContent: 'center',
    }}>
      <div style={{
        background: '#fff', borderRadius: '20px', padding: '36px 32px',
        maxWidth: '380px', width: '90%', textAlign: 'center',
        boxShadow: '0 20px 60px rgba(0,0,0,0.25)',
        animation: 'popIn 0.2s cubic-bezier(.175,.885,.32,1.275)',
      }}>
        <div style={{ fontSize: '3rem', marginBottom: '12px' }}>⚠️</div>
        <h2 style={{ margin: '0 0 8px', color: '#1e293b', fontWeight: 800, fontSize: '1.25rem' }}>
          ¿Reiniciar evaluación?
        </h2>
        <p style={{ color: '#64748b', marginBottom: '24px', lineHeight: 1.5 }}>
          Perderás todo tu progreso actual y comenzarás desde las primeras <strong>5 preguntas fáciles</strong>.
        </p>
        <div style={{ display: 'flex', gap: '12px', justifyContent: 'center' }}>
          <button
            id="btn-restart-confirm"
            onClick={onConfirm}
            style={{
              background: 'linear-gradient(135deg, #ef4444, #dc2626)',
              color: '#fff', border: 'none', borderRadius: '12px',
              padding: '11px 24px', fontWeight: 700, fontSize: '0.95rem',
              cursor: 'pointer', flex: 1,
              boxShadow: '0 4px 12px rgba(239,68,68,0.35)',
            }}
          >
            Sí, reiniciar
          </button>
          <button
            id="btn-restart-cancel"
            onClick={onCancel}
            style={{
              background: '#f1f5f9', color: '#475569',
              border: '1.5px solid #cbd5e1', borderRadius: '12px',
              padding: '11px 24px', fontWeight: 700, fontSize: '0.95rem',
              cursor: 'pointer', flex: 1,
            }}
          >
            Cancelar
          </button>
        </div>
      </div>
      <style>{`@keyframes popIn{from{transform:scale(0.75);opacity:0}to{transform:scale(1);opacity:1}}`}</style>
    </div>
  );
}

// ── Componente principal ─────────────────────────────────────────────────────
export default function Exam({ user, onLogout }) {
  const [question, setQuestion] = useState(null);
  const [status, setStatus] = useState(null);
  const [selected, setSelected] = useState(null);
  const [feedback, setFeedback] = useState(null);
  const [loading, setLoading] = useState(true);
  const [submitting, setSubmitting] = useState(false);
  const [finished, setFinished] = useState(false);
  const [error, setError] = useState('');
  const [showLevelUp, setShowLevelUp] = useState(false);
  const [levelUpLoading, setLevelUpLoading] = useState(false);
  const [showRestartConfirm, setShowRestartConfirm] = useState(false);
  const [restarting, setRestarting] = useState(false);

  const userId = user.username;

  useEffect(() => { loadQuestion(); }, []);

  // ── Carga de siguiente pregunta ──────────────────────────────────────────
  const loadQuestion = async () => {
    setLoading(true);
    setSelected(null);
    setFeedback(null);
    setError('');
    try {
      const s = await api.getStatus(userId);
      setStatus(s);

      if (s.isCompleted) {
        setFinished(true);
        setLoading(false);
        return;
      }

      const q = await api.getNextQuestion(userId);
      setQuestion(q);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  // ── Envío de respuesta ───────────────────────────────────────────────────
  const handleSubmit = async () => {
    if (selected === null) return;
    setSubmitting(true);
    setError('');
    try {
      const result = await api.submitAnswer(userId, selected);
      setFeedback(result);
      setStatus(result.nextStatus);

      if (result.nextStatus?.isCompleted) {
        setFinished(true);
      } else if (result.levelUpTriggered) {
        // Mostrar modal de subida de nivel
        setShowLevelUp(true);
      }
    } catch (err) {
      setError(err.message);
    } finally {
      setSubmitting(false);
    }
  };

  // ── Respuesta al modal de subida de nivel ────────────────────────────────
  // El backend devuelve la siguiente pregunta directamente → sin viaje extra
  const handleLevelUpResponse = async (accept) => {
    setLevelUpLoading(true);
    try {
      const result = await api.confirmLevelUp(userId, accept);

      // Actualizar estado con el nuevo nivel
      setStatus(prev => ({
        ...prev,
        currentDifficulty: result.newDifficulty,
        consecutiveHits: 0,
        levelUpPending: false,
      }));

      setShowLevelUp(false);

      // Cargar la siguiente pregunta que el backend ya calculó
      if (result.nextQuestion) {
        setQuestion(result.nextQuestion);
        setSelected(null);
        setFeedback(null);
      } else {
        // Fallback: pedir manualmente si no venía en la respuesta
        await loadQuestion();
      }
    } catch (err) {
      setError(err.message);
      setShowLevelUp(false);
    } finally {
      setLevelUpLoading(false);
    }
  };

  // ── Reinicio mid-exam ────────────────────────────────────────────────────
  const handleRestartConfirmed = async () => {
    setShowRestartConfirm(false);
    setRestarting(true);
    try {
      await api.restartExam(userId);
      setFinished(false);
      setShowLevelUp(false);
      await loadQuestion();
    } catch (err) {
      setError(err.message);
    } finally {
      setRestarting(false);
    }
  };

  // ── Métricas ─────────────────────────────────────────────────────────────
  const progressPercent = status
    ? Math.round((status.totalQuestionsAsked / 30) * 100)
    : 0;

  const diffLevel = status?.currentDifficulty ?? 3;
  const diffCfg = DIFFICULTY_CONFIG[diffLevel] ?? DIFFICULTY_CONFIG[3];

  // ── Loading ──────────────────────────────────────────────────────────────
  if (loading || restarting) {
    return (
      <div className="exam-container text-center py-5">
        <div className="spinner-border text-primary" role="status">
          <span className="visually-hidden">Cargando...</span>
        </div>
        <p className="mt-3 text-muted">
          {restarting ? 'Reiniciando evaluación...' : 'Cargando pregunta...'}
        </p>
      </div>
    );
  }

  // ── Finalizado ───────────────────────────────────────────────────────────
  if (finished) {
    const pct = status?.totalQuestionsAsked
      ? Math.round((status.totalCorrectAnswers / status.totalQuestionsAsked) * 100)
      : 0;
    return (
      <div className="exam-container">
        <div className="card shadow text-center p-5">
          <div className="mb-4">
            <i className="bi bi-trophy-fill text-warning" style={{ fontSize: '4rem' }}></i>
          </div>
          <h2 className="fw-bold">¡Evaluación Completada!</h2>
          <p className="text-muted fs-5 mt-3">
            Respondiste <strong>{status?.totalCorrectAnswers}</strong> de{' '}
            <strong>{status?.totalQuestionsAsked}</strong> preguntas correctamente.
          </p>
          <div className="mt-3">
            <span className={`badge fs-5 px-4 py-2 ${pct >= 70 ? 'bg-success' : 'bg-danger'}`}>
              {pct}% de aciertos
            </span>
          </div>
          <div className="mt-4 d-flex justify-content-center gap-3">
            <button className="btn btn-primary" onClick={() => setShowRestartConfirm(true)}>
              <i className="bi bi-arrow-clockwise me-2"></i>Realizar Nueva Evaluación
            </button>
            <button className="btn btn-outline-secondary" onClick={onLogout}>
              <i className="bi bi-box-arrow-left me-2"></i>Cerrar Sesión
            </button>
          </div>
        </div>
        {showRestartConfirm && (
          <RestartConfirmModal
            onConfirm={handleRestartConfirmed}
            onCancel={() => setShowRestartConfirm(false)}
          />
        )}
      </div>
    );
  }

  // ── Examen en curso ──────────────────────────────────────────────────────
  return (
    <div className="exam-container">

      {/* Modales */}
      {showLevelUp && (
        <LevelUpModal
          currentDifficulty={diffLevel}
          onAccept={() => handleLevelUpResponse(true)}
          onReject={() => handleLevelUpResponse(false)}
          loading={levelUpLoading}
        />
      )}
      {showRestartConfirm && (
        <RestartConfirmModal
          onConfirm={handleRestartConfirmed}
          onCancel={() => setShowRestartConfirm(false)}
        />
      )}

      {/* Header */}
      <div className="d-flex justify-content-between align-items-center mb-3">
        <div>
          <h4 className="fw-bold mb-0">
            <i className="text-white bi bi-journal-text me-2"></i>Evaluación CENEVAL
          </h4>
          <small className="text-white">Bienvenido, {user.fullName}</small>
        </div>
        <div className="d-flex align-items-center gap-2 flex-wrap justify-content-end">
          <DifficultyBadge difficulty={diffLevel} consecutiveHits={status?.consecutiveHits ?? 0} />

          {/* Botón reiniciar mid-exam */}
          <button
            id="btn-restart-mid"
            className="btn btn-sm"
            title="Reiniciar evaluación"
            onClick={() => setShowRestartConfirm(true)}
            style={{
              background: '#fff3f3', color: '#ef4444',
              border: '1.5px solid #fca5a5', borderRadius: '10px',
              fontWeight: 600, fontSize: '0.8rem',
              padding: '5px 12px',
            }}
          >
            <i className="bi bi-arrow-counterclockwise me-1"></i>Reiniciar
          </button>

          <button
            id="btn-logout"
            className="btn btn-outline-secondary btn-sm"
            onClick={onLogout}
          >
            <i className="bi bi-box-arrow-left me-1"></i>Salir
          </button>
        </div>
      </div>

      {/* Barra de progreso */}
      {status && (
        <div className="mb-4">
          <div className="d-flex justify-content-between mb-1">
            <small className="text-muted fw-semibold">Progreso</small>
            <small className="text-muted">
              {status.totalQuestionsAsked}/30 —{' '}
              <span className="text-success">{status.totalCorrectAnswers} correctas</span>
            </small>
          </div>
          <div className="progress" style={{ height: '10px' }}>
            <div
              className="progress-bar"
              role="progressbar"
              style={{
                width: `${progressPercent}%`,
                background: `linear-gradient(90deg, ${diffCfg.color}, ${diffCfg.border})`,
                transition: 'width 0.5s ease',
              }}
            />
          </div>
        </div>
      )}

      {error && (
        <div className="alert alert-danger py-2">
          <i className="bi bi-exclamation-triangle-fill me-2"></i>{error}
        </div>
      )}

      {/* Tarjeta de pregunta */}
      {question && (
        <div className="card shadow-sm" style={{
          borderTop: `4px solid ${diffCfg.color}`,
          borderRadius: '14px',
        }}>
          <div className="card-body p-4">
            <h5 className="card-title fw-bold mb-4">
              <span className="badge me-2" style={{ background: diffCfg.color }}>
                Pregunta {(status?.totalQuestionsAsked || 0) + 1}
              </span>
              {question.content}
            </h5>

            <div className="options-list">
              {question.options?.map((opt) => (
                <button
                  key={opt.optionId}
                  id={`opt-${opt.optionId}`}
                  className={`btn option-btn w-100 text-start mb-2 p-3 ${feedback
                    ? opt.optionId === selected
                      ? feedback.correct ? 'btn-success text-white' : 'btn-danger text-white'
                      : 'btn-outline-secondary disabled'
                    : selected === opt.optionId
                      ? 'btn-primary text-white'
                      : 'btn-outline-secondary'
                    }`}
                  onClick={() => !feedback && setSelected(opt.optionId)}
                  disabled={!!feedback}
                >
                  <i className={`bi me-2 ${feedback
                    ? opt.optionId === selected
                      ? feedback.correct ? 'bi-check-circle-fill' : 'bi-x-circle-fill'
                      : 'bi-circle'
                    : selected === opt.optionId
                      ? 'bi-record-circle-fill'
                      : 'bi-circle'
                    }`}></i>
                  {opt.text}
                </button>
              ))}
            </div>

            {/* Feedback */}
            {feedback && !showLevelUp && (
              <div className={`alert mt-3 ${feedback.correct ? 'alert-success' : 'alert-warning'}`}>
                <i className={`bi me-2 ${feedback.correct ? 'bi-check-circle-fill' : 'bi-lightbulb-fill'}`}></i>
                <strong>{feedback.correct ? '¡Correcto!' : 'Incorrecto.'}</strong>
                {feedback.feedback && <p className="mb-0 mt-1">{feedback.feedback}</p>}
              </div>
            )}

            {/* Botones de acción */}
            <div className="d-flex justify-content-end mt-3">
              {!feedback ? (
                <button
                  id="btn-submit-answer"
                  className="btn btn-primary px-4 py-2 fw-semibold"
                  onClick={handleSubmit}
                  disabled={selected === null || submitting}
                >
                  {submitting ? (
                    <><span className="spinner-border spinner-border-sm me-2"></span>Enviando...</>
                  ) : (
                    <><i className="bi bi-send-fill me-2"></i>Responder</>
                  )}
                </button>
              ) : (
                /* Solo mostrar "Siguiente" si NO hay modal de level-up pendiente */
                !showLevelUp && (
                  <button
                    id="btn-next-question"
                    className="btn btn-primary px-4 py-2 fw-semibold"
                    onClick={loadQuestion}
                  >
                    <i className="bi bi-arrow-right me-2"></i>Siguiente Pregunta
                  </button>
                )
              )}
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
